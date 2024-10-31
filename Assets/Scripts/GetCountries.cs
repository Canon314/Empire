using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CountryController : MonoBehaviour
{
    public List<GameObject> countries;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadScene();
    }
    void LoadScene()
    {
        foreach (GameObject country in countries)
        {
            ColorHandler colorHandler = country.GetComponent<ColorHandler>();
            Saver data = SaveSystem.LoadSaved(colorHandler);
            if (data != null)
            {
                colorHandler.armyText.text = data.armies;
                colorHandler.CurrentColor = data.GetColor();
            }
            else
            {
                colorHandler.CurrentColor = Color.white;
                colorHandler.armyText.text = "";
            }
        }
    }
    public void SaveState()
    {
        foreach (GameObject country in countries)
        {
            SaveSystem.SaveState(country.GetComponent<ColorHandler>());
        }


    }

    public void ResetState()
    {
        foreach (GameObject country in countries)
        {
            ColorHandler colorHandler = country.GetComponent<ColorHandler>();
            string path = Path.Combine(Application.persistentDataPath, $"gamestate{colorHandler.name}{SceneManager.GetActiveScene().name}.dat");

            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                    Debug.Log($"State file deleted for {colorHandler.name}");
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"Error deleting state file for {colorHandler.name}: {e.Message}");
                }
            }

            // Reset the country to its default state
            colorHandler.CurrentColor = Color.white;
            colorHandler.armyText.text = "";
        }
    }
}