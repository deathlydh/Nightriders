using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MuteMusic : MonoBehaviour
{
    public AudioMixer mixer; // Ссылка на аудио микшер
    public float previousVolume = 0f; // Предыдущее значение громкости
    public Sprite soundOnIcon; // Иконка для включенного звука
    public Sprite soundOffIcon; // Иконка для выключенного звука
    public Image buttonImage; // Ссылка на изображение кнопки

    private bool isMuted = false; // Переменная для отслеживания состояния звука
    private const string MUTE_KEY = "IsMuted"; // Ключ для сохранения состояния звука в PlayerPrefs

    private void Start()
    {
        // Проверяем, сохранено ли состояние мута в PlayerPrefs
        if (PlayerPrefs.HasKey(MUTE_KEY))
        {
            isMuted = PlayerPrefs.GetInt(MUTE_KEY) == 1;
            SetMuteState(isMuted);
        }
    }

    // Метод для выключения звука или возврата к предыдущему значению
    public void ToggleMute()
    {
        isMuted = !isMuted; // Инвертируем состояние звука
        SetMuteState(isMuted);

        // Сохраняем состояние мута в PlayerPrefs
        PlayerPrefs.SetInt(MUTE_KEY, isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    // Метод для установки состояния мута
    private void SetMuteState(bool muted)
    {
        if (muted)
        {
            mixer.SetFloat("MasterVolume", -80f);
            buttonImage.sprite = soundOffIcon;
        }
        else
        {
            mixer.SetFloat("MasterVolume", previousVolume);
            buttonImage.sprite = soundOnIcon;
        }
    }
}
