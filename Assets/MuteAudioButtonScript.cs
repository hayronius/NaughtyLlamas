using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudioButtonScript : MonoBehaviour
{
    public bool audioOn = true;
    public void ToggleAudio()
    {
        audioOn = !audioOn;
        if (!audioOn)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }

}
