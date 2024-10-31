using UnityEngine;
using UnityEngine.EventSystems;
public class DeselectPanel : MonoBehaviour
{
    public SelectCountry selectCountry;
    private ColorHandler selectCountryRender;
    private void OnMouseDown()
    {
        if (selectCountry.originalColor != Color.clear)
        {
            selectCountryRender = selectCountry.lastClickedCountry.GetComponent<ColorHandler>();
            selectCountryRender.spriteRenderer.color = Color.red;
            selectCountryRender.spriteRenderer.color = selectCountry.originalColor;
        }

        selectCountry.lastClickedCountry = null;
        selectCountry.originalColor = Color.clear;
        Debug.Log("Clicked on reset panel, lastClickedCountry reset to null.");
    }
}