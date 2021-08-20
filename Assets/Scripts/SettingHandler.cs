using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingHandler : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    /*
    Set Main Volume through the Audio Mixer
    */
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetGraphicQuality(int quialityIndex) 
    {
        QualitySettings.SetQualityLevel(quialityIndex);

        // Test printing current Quality Level
        // print(QualitySettings.GetQualityLevel());
    }
}
