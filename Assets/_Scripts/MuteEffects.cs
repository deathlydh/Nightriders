using UnityEngine;
using UnityEngine.Audio;

public class MuteEffects : MonoBehaviour
{
    public AudioMixer mixer; // ������ �� ����� ������
    public VolumeController volumeController; // ������ �� ��������� VolumeController

    private void Start()
    {
        UpdateVolume(); // ��������� �������� ��������� ��� ������� �����
    }

    private void Update()
    {
        CheckTimeScale();
    }

    private void CheckTimeScale()
    {
        float timeScale = Time.timeScale; // ��������� ������� �������� Time.timeScale ��� �������

        if (timeScale == 0f)
        {
            // ���� Time.timeScale ����� 0, ��������� ����
            mixer.SetFloat("EffectsVol", -80f);
        }
        else
        {
            // � ��������� ������, ���������� �������� ��������� �� VolumeController
            UpdateVolume(); // ��������� �������� ���������
        }
    }

    private void UpdateVolume()
    {
        if (volumeController != null)
        {
            float volume = PlayerPrefs.GetFloat(volumeController.volumeParameter, 0f); // �������� �������� ��������� �� PlayerPrefs
            mixer.SetFloat("EffectsVol", volume);
        }
        else
        {
            Debug.LogError("VolumeController �� �������� � MuteEffects.");
        }
    }
}
