using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarController : MonoBehaviour
{
    public TextMeshProUGUI valueText;
    public Slider slider;
    
    public void OnBarChanged(float value)
    {
        valueText.text = value.ToString();
    }

    public void UpdateBar(int change)
    {
        slider.value += change;
    }
}
