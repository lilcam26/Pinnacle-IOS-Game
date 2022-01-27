using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void setHeight(float Height){

        slider.value = Height;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
