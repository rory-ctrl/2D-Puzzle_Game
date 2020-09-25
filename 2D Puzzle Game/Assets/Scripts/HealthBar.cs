﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void setHealth(int health){
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void setMaxHealth(int health){
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
}
