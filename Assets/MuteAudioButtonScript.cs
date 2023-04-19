using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudioButtonScript : MonoBehaviour
{
    public bool audioOn = true;

    private GameObject goAudioOn;
    private GameObject goAudioOff;

    public void Start()
    {
        goAudioOn = this.gameObject.transform.GetChild(0).gameObject;
        goAudioOff = this.gameObject.transform.GetChild(1).gameObject;
    }

    public void ToggleAudio()
    {
        audioOn = !audioOn;
        if (!audioOn)
        {
            AudioListener.volume = 0;
            goAudioOn.SetActive(false);
            goAudioOff.SetActive(true);
        }
        else
        {
            AudioListener.volume = 1;
            goAudioOn.SetActive(true);
            goAudioOff.SetActive(false);
        }
    }
}
