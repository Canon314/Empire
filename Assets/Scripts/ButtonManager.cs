using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public List<ButtonTextHandler> buttons; // List of ButtonTextHandler components

    public void SaveAllButtonStates()
    {
        foreach (ButtonTextHandler buttonHandler in buttons)
        {
            buttonHandler.SaveButtonText();
        }
    }

    public void LoadAllButtonStates()
    {
        foreach (ButtonTextHandler buttonHandler in buttons)
        {
            buttonHandler.LoadButtonText();
        }
    }

    public void ResetButtonStates()
    {
        foreach (ButtonTextHandler buttonHandler in buttons)
        {
            string path = Path.Combine(Application.persistentDataPath, $"buttonstate{buttonHandler.name}{SceneManager.GetActiveScene().name}.dat");

            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                    Debug.Log($"State file deleted for {buttonHandler.name}");
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"Error deleting state file for {buttonHandler.name}: {e.Message}");
                }
            }

            // Reset the button to its default state
            buttonHandler.buttonText.text = ""; // Replace "Default Text" with whatever the default should be
        }
    }
}
