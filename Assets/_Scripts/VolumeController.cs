using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    public Slider slider;
    public GameObject sliderObject;

    public float _volumeValue;
    private const float _multiplier = 20f;

    public UnityEvent<float> OnVolumeChanged; // Событие, вызываемое при изменении громкости

    private void Awake()
    {
        Persist(); // Сохраняем объект при загрузке сцены
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        _volumeValue = Mathf.Log10(value) * _multiplier;
        mixer.SetFloat(volumeParameter, _volumeValue);
        OnVolumeChanged.Invoke(_volumeValue); // Вызываем событие при изменении громкости
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadVolume(); // Загружаем значение громкости при запуске сцены
        UpdateSliderValue(); // Обновляем значение слайдера
    }

    private void OnDisable()
    {
        SaveVolume(); // Сохраняем значение громкости при выгрузке сцены
    }

    // Метод для обновления значения слайдера с текущим значением громкости
    public void UpdateSliderValue()
    {
        slider.value = Mathf.Pow(10f, _volumeValue / _multiplier);
    }

    // Метод для сохранения значения громкости в PlayerPrefs
    private void SaveVolume()
    {
        PlayerPrefs.SetFloat(volumeParameter, _volumeValue);
    }

    // Метод для загрузки значения громкости из PlayerPrefs
    private void LoadVolume()
    {
        _volumeValue = PlayerPrefs.GetFloat(volumeParameter, Mathf.Log10(slider.value) * _multiplier);
        mixer.SetFloat(volumeParameter, _volumeValue);
    }

    // Метод для сохранения объекта при загрузке новой сцены
    private void Persist()
    {
        DontDestroyOnLoad(gameObject);
    }
}
