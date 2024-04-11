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

    public UnityEvent<float> OnVolumeChanged; // �������, ���������� ��� ��������� ���������

    private void Awake()
    {
        Persist(); // ��������� ������ ��� �������� �����
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        _volumeValue = Mathf.Log10(value) * _multiplier;
        mixer.SetFloat(volumeParameter, _volumeValue);
        OnVolumeChanged.Invoke(_volumeValue); // �������� ������� ��� ��������� ���������
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadVolume(); // ��������� �������� ��������� ��� ������� �����
        UpdateSliderValue(); // ��������� �������� ��������
    }

    private void OnDisable()
    {
        SaveVolume(); // ��������� �������� ��������� ��� �������� �����
    }

    // ����� ��� ���������� �������� �������� � ������� ��������� ���������
    public void UpdateSliderValue()
    {
        slider.value = Mathf.Pow(10f, _volumeValue / _multiplier);
    }

    // ����� ��� ���������� �������� ��������� � PlayerPrefs
    private void SaveVolume()
    {
        PlayerPrefs.SetFloat(volumeParameter, _volumeValue);
    }

    // ����� ��� �������� �������� ��������� �� PlayerPrefs
    private void LoadVolume()
    {
        _volumeValue = PlayerPrefs.GetFloat(volumeParameter, Mathf.Log10(slider.value) * _multiplier);
        mixer.SetFloat(volumeParameter, _volumeValue);
    }

    // ����� ��� ���������� ������� ��� �������� ����� �����
    private void Persist()
    {
        DontDestroyOnLoad(gameObject);
    }
}
