using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    public TextMeshProUGUI maxHealthText;
    public TextMeshProUGUI currentHealthText;

    public int maxHealth = 10;
    public int currentHealth = 10; 

    public void increaseMaxHealth()
    {
        maxHealth += 2;
    }

    public void playerDamaged(int damage)
    {
        currentHealth -= damage;
    }

    void Update()
    {

        slider.value = currentHealth;

        //string maxHealthString = maxHealth.toString();
        //string currentHealthString = currentHealth.toString();

        maxHealthText.SetText(maxHealth.ToString());
        currentHealthText.SetText(currentHealth.ToString());

    }

}
