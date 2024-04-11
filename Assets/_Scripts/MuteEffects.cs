using UnityEngine;
using UnityEngine.Audio;

public class MuteEffects : MonoBehaviour
{
    public AudioMixer mixer; // Ссылка на аудио микшер
    public VolumeController volumeController; // Ссылка на компонент VolumeController

    private void Start()
    {
        UpdateVolume(); // Обновляем значение громкости при запуске сцены
    }

    private void Update()
    {
        CheckTimeScale();
    }

    private void CheckTimeScale()
    {
        float timeScale = Time.timeScale; // Сохраняем текущее значение Time.timeScale для отладки

        if (timeScale == 0f)
        {
            // Если Time.timeScale равно 0, выключаем звук
            mixer.SetFloat("EffectsVol", -80f);
        }
        else
        {
            // В противном случае, используем значение громкости из VolumeController
            UpdateVolume(); // Обновляем значение громкости
        }
    }

    private void UpdateVolume()
    {
        if (volumeController != null)
        {
            float volume = PlayerPrefs.GetFloat(volumeController.volumeParameter, 0f); // Получаем значение громкости из PlayerPrefs
            mixer.SetFloat("EffectsVol", volume);
        }
        else
        {
            Debug.LogError("VolumeController не назначен в MuteEffects.");
        }
    }
}
