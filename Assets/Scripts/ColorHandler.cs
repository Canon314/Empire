using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Collections;

[RequireComponent(typeof(PolygonCollider2D), typeof(SpriteRenderer))]
public class ColorHandler : MonoBehaviour
{
    [Serializable]
    public class Country
    {
        public string name;
        public string color;
    }

    public Country country;


    private SelectCountry selectCountry;
    private ColorHandler selectCountryRenderer;
    private Attack attack;

    public Text armyText;

    public SpriteRenderer spriteRenderer;


    public Color CurrentColor
    {
        get => spriteRenderer.color;
        set
        {
            spriteRenderer.color = value;
            country.color = UnityEngine.ColorUtility.ToHtmlStringRGBA(value);
        }
    }

    void Start()
    {
        selectCountry = FindObjectOfType<SelectCountry>();
        attack = FindObjectOfType<Attack>();
    }


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CurrentColor = spriteRenderer.color;
        armyText.text = "";
    }


    private void OnMouseDown()
    {
        if (selectCountry.lastClickedCountry != null)
        {
            if (attack.isAttacking == true && selectCountry.lastClickedCountry != gameObject)
            {
                attack.secondSelectedCountry = gameObject.GetComponent<ColorHandler>();
                attack.firstSelectedCountry.armyText.color = Color.black;
                if (attack.firstSelectedCountry.GetArmyValue() < attack.secondSelectedCountry.GetArmyValue())
                {
                    selectCountry.lastClickedCountry = null;
                    selectCountry.originalColor = Color.clear;
                }
                else
                {
                    selectCountry.lastClickedCountry.GetComponent<ColorHandler>().spriteRenderer.color = selectCountry.originalColor;
                    selectCountry.lastClickedCountry = null;
                    selectCountry.originalColor = Color.clear;

                }
                attack.PerformAttack();
                attack.isAttacking = false;
                
                return;
            }

            else if (selectCountry.lastClickedCountry == gameObject)
            {
                if (attack.isAttacking == true)
                {
                    attack.isAttacking = false;
                    armyText.color = Color.black;
                    Debug.Log("Black");
                    return;
                }
                else
                {
                    attack.isAttacking = true;
                    attack.firstSelectedCountry = gameObject.GetComponent<ColorHandler>();
                    armyText.color = Color.red;
                    Debug.Log("Red");
                    return;
                }
            }
        }
        
        if (selectCountry.originalColor != Color.clear && selectCountry.lastClickedCountry != null)
        {
            selectCountryRenderer = selectCountry.lastClickedCountry.GetComponent<ColorHandler>();
            selectCountryRenderer.spriteRenderer.color = selectCountry.originalColor;
        }


        selectCountry.OnCountryClicked(gameObject);
        if (attack.isAttacking == false)
        {
            selectCountry.originalColor = CurrentColor;
            spriteRenderer.color = DarkenColor(CurrentColor, 0.2f);
        }
    }

    public int GetArmyValue()
    {
        return string.IsNullOrEmpty(armyText.text) ? 0 : int.Parse(armyText.text);
    }

    public void SetArmyValue(int value)
    {
        armyText.text = value > 0 ? value.ToString() : "";
    }

    private void OnValidate()
    {
        country.name = name;
    }

    private static Color DarkenColor(Color color, float factor)
    {
        return new Color(
            Mathf.Max(color.r - factor, 0),
            Mathf.Max(color.g - factor, 0),
            Mathf.Max(color.b - factor, 0),
            color.a
        );
    }
}