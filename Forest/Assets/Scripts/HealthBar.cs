using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Vector3 offset;
    public float maxHealth;
    public void SetHealth(float health)
    {
        slider.gameObject.SetActive(health > 0); 
        slider.value = health; 
        slider.maxValue = maxHealth; 
    }


    

    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position +  offset);
    }
}
