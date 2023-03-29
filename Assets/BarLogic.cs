using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fungus;

public class BarLogic : MonoBehaviour
{
    public TextMeshProUGUI valueText;
    public Slider slider;
    public VariableReference var;

    public void OnBarChanged(float value)
    {
        valueText.text = value.ToString();
    }

    public void UpdateBar(int change)
    {
        slider.value = change;
    }

    void Update()
    {
        UpdateBar(var.Get<int>());
    }
}
