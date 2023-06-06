using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettingPanel : MonoBehaviour
{
    public AudioManager audioManager;
    public Slider volumeSlider;
    public TextMeshProUGUI volumeText;


    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void OnVolumeChanged(float volume)
    {
        audioManager.SetSoundVolume(volume);
        volumeText.text = "Volume Suara: " + (volume * 100).ToString("0") + "%";
    }

}
