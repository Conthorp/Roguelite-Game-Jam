using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{

    public Slider slider;

    public TextMeshProUGUI XPToLevelText;
    public TextMeshProUGUI currentXPText;
    public TextMeshProUGUI currentLevelText;

    public int XPToLevel = 100;
    public int currentXP = 0;
    public int currentLevel = 1;

    public int multiplier = 2;

    public void XPGain(int XPAmount)
    {
        currentXP += XPAmount;
        
        if (currentXP >=XPToLevel)
        {

            currentLevel ++;
            currentXP = currentXP -= XPToLevel;
            XPToLevel = XPToLevel * multiplier;

        }
    }

    void Update()
    {

        slider.value = currentXP;

        //string maxHealthString = maxHealth.toString();
        //string currentHealthString = currentHealth.toString();

        XPToLevelText.SetText(XPToLevel.ToString());
        currentXPText.SetText(currentXP.ToString());
        currentLevelText.SetText(currentLevel.ToString());


    }

}
