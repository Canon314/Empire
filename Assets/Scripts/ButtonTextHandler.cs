using UnityEngine;
using UnityEngine.UI;

public class ButtonTextHandler : MonoBehaviour
{
    public Text buttonText;

    private void Start()
    {
        LoadButtonText();
    }

    public void SaveButtonText()
    {
        SaveSystem.SaveButtonState(this);
    }

    public void LoadButtonText()
    {
        Saver data = SaveSystem.LoadButtonState(this);
        if (data != null)
        {
            buttonText.text = data.text;
        }
        else
        {
            buttonText.text = ""; // Set to default text if no saved data is found
        }
    }
}
