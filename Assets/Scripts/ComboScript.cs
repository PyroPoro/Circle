using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboScript : MonoBehaviour
{
    public Text comboText;
    public Text comboMultiplierText;
    private int combo = 0;
    private float comboMultiplier = 1.0f;
    private int comboNum = 0;
    void Start()
    {
    }

    void Update()
    {
        comboText.text = combo.ToString();
        comboNum = combo / 50;
        updateComboMultiplier();
        comboMultiplierText.text = "x " + comboMultiplier.ToString();
        
    }
    public void incrementCombo(){
        combo++;
    }
    public void resetCombo(){
        combo = 0;
    }
    public float getComboMultiplier(){
        return comboMultiplier;
    }
    private void updateComboMultiplier(){
        switch(comboNum){
            case 0:
                comboMultiplier = 1.0f;
                break;
            case 1:
                comboMultiplier = 1.05f;
                break;
            case 2:
                comboMultiplier = 1.10f;
                break;
            case 3:
                comboMultiplier = 1.15f;
                break;
            case 4:
                comboMultiplier = 1.20f;
                break;
            case 5:
                comboMultiplier = 1.25f;
                break;
            case 6:
                comboMultiplier = 1.30f;
                break;
            case 7:
                comboMultiplier = 1.35f;
                break;
            case 8:
                comboMultiplier = 1.40f;
                break;
            case 9:
                comboMultiplier = 1.45f;
                break;
            case 10:
                comboMultiplier = 1.50f;
                break;
            case 11:
                comboMultiplier = 1.55f;
                break;
        }
    }
}
