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
    public static int currentLevel = 1;

    public void XPGain(int XPAmount)
    {
        currentXP += XPAmount;
        
        if (currentXP >=XPToLevel)
        {
            currentXP = currentXP -= XPToLevel;
            currentLevel ++;
        }
    }

    void Update()
    {

        slider.value = currentXP;

        XPToLevel = currentLevel * 100;

        XPToLevelText.SetText(XPToLevel.ToString());
        currentXPText.SetText(currentXP.ToString());
        currentLevelText.SetText(currentLevel.ToString());


    }

}
