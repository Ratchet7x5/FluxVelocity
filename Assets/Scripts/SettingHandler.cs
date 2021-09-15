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

    /*
    Change game graph quality with GraphicDropDown in SettingMenu

    Quality Options : Ultra Low, Low, Medium, High, Ultra High 
    */
    public void SetGraphicQuality(int quialityIndex) 
    {
        // Change game Graphic quality with given index number in DropDown
        QualitySettings.SetQualityLevel(quialityIndex);

        // Test printing current Quality Level
        // print(QualitySettings.GetQualityLevel());
    }
}
