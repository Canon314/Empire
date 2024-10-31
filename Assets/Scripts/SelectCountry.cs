using UnityEngine;
public class SelectCountry : MonoBehaviour
{
    private CountryController countryController;
    public GameObject lastClickedCountry;
    public Color originalColor;
    void Start()
    {
        // Get the CountryController component on the same GameObject
        countryController = GetComponent<CountryController>();
    }
    public void OnCountryClicked(GameObject clickedCountry)
    {
        // Check if the clicked object is in the list of countries
        if (countryController.countries.Contains(clickedCountry))
        {
            lastClickedCountry = clickedCountry;
            Debug.Log("Last clicked country: " + lastClickedCountry.name);
        }
        else
        {
            lastClickedCountry = null;
        }
    }
}