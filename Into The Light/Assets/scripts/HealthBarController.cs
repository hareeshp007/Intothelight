using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    public Slider HealthBarSlider;
    public Gradient HealthGradient;
    public Image fill;

    public void SetMaxHealth(float MaxHealth)
    {
        HealthBarSlider.maxValue = MaxHealth;
        HealthBarSlider.value = MaxHealth;
        fill.color = HealthGradient.Evaluate(1f);
    }
    public void SetHealth(float health)
    {
        HealthBarSlider.value = health;
        fill.color = HealthGradient.Evaluate(HealthBarSlider.normalizedValue);
    }
}
