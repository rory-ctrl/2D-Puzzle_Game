using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void setTime(float time){
        slider.value = time;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void setMaxTime(int time){
        slider.maxValue = time;
        slider.value = time;

        fill.color = gradient.Evaluate(1f);
    }
}
