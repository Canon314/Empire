using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public Button Button;


    private SelectCountry selectCountry;
    private ColorHandler selectCountryRenderer;

    void Start()
    {
        selectCountry = FindObjectOfType<SelectCountry>();
    }

    public void SetColor()
    {
        if (selectCountry.lastClickedCountry != null)
        {
            ColorBlock colors = Button.colors;
            selectCountry.originalColor = colors.normalColor;

            selectCountryRenderer = selectCountry.lastClickedCountry.GetComponent<ColorHandler>();
            selectCountryRenderer.spriteRenderer.color = new UnityEngine.Color(
                Mathf.Max(colors.normalColor.r - 0.2f, 0),
                Mathf.Max(colors.normalColor.g - 0.2f, 0),
                Mathf.Max(colors.normalColor.b - 0.2f, 0),
                colors.normalColor.a);
        }  
    }

    public void DecreaseArmy()
    {
        if (selectCountry.lastClickedCountry != null)
        {
            selectCountryRenderer = selectCountry.lastClickedCountry.GetComponent<ColorHandler>();

            if (selectCountryRenderer.armyText.text != "" && selectCountryRenderer.armyText.text != "0")
            {
                int armyValue = int.Parse(selectCountryRenderer.armyText.text);
                armyValue--;

                if (armyValue <= 0)
                {
                    selectCountryRenderer.armyText.text = null;
                }
                else
                {
                    selectCountryRenderer.armyText.text = armyValue.ToString();
                }
            }
        }
    }

    public void IncreaseArmy()
    {
        if (selectCountry.lastClickedCountry != null)
        {
            selectCountryRenderer = selectCountry.lastClickedCountry.GetComponent<ColorHandler>();
            if (selectCountryRenderer.armyText.text == "")
            {
                selectCountryRenderer.armyText.text = "1";
            }
            else
            {
                int armyValue = int.Parse(selectCountryRenderer.armyText.text);
                armyValue++;
                selectCountryRenderer.armyText.text = armyValue.ToString();
            }
        }
    }
}