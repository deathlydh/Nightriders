using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MuteMusic : MonoBehaviour
{
    public AudioMixer mixer; // ������ �� ����� ������
    public float previousVolume = 0f; // ���������� �������� ���������
    public Sprite soundOnIcon; // ������ ��� ����������� �����
    public Sprite soundOffIcon; // ������ ��� ������������ �����
    public Image buttonImage; // ������ �� ����������� ������

    private bool isMuted = false; // ���������� ��� ������������ ��������� �����
    private const string MUTE_KEY = "IsMuted"; // ���� ��� ���������� ��������� ����� � PlayerPrefs

    private void Start()
    {
        // ���������, ��������� �� ��������� ���� � PlayerPrefs
        if (PlayerPrefs.HasKey(MUTE_KEY))
        {
            isMuted = PlayerPrefs.GetInt(MUTE_KEY) == 1;
            SetMuteState(isMuted);
        }
    }

    // ����� ��� ���������� ����� ��� �������� � ����������� ��������
    public void ToggleMute()
    {
        isMuted = !isMuted; // ����������� ��������� �����
        SetMuteState(isMuted);

        // ��������� ��������� ���� � PlayerPrefs
        PlayerPrefs.SetInt(MUTE_KEY, isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    // ����� ��� ��������� ��������� ����
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
