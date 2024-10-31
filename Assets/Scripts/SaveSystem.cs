using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
public static class SaveSystem
{
    private static string GetSavePath(ColorHandler handler)
    {
        return Path.Combine(Application.persistentDataPath, $"gamestate{handler.name}{SceneManager.GetActiveScene().name}.dat");
    }
    public static void SaveState(ColorHandler handler)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = GetSavePath(handler);
        try
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                Saver data = new Saver(handler);
                bf.Serialize(stream, data);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error saving data: {e.Message}");
        }
    }
    public static Saver LoadSaved(ColorHandler handler)
    {
        string path = GetSavePath(handler);
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    return bf.Deserialize(stream) as Saver;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogWarning($"Error loading save file for {handler.name}: {e.Message}");
                // Delete the corrupted file
                File.Delete(path);
            }
        }
        else
        {
            Debug.LogWarning($"Save file not found for {handler.name}.");
        }
        return null;
    }

    public static void SaveButtonState(ButtonTextHandler buttonHandler)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, $"buttonstate{buttonHandler.name}{SceneManager.GetActiveScene().name}.dat");
        FileStream stream = new FileStream(path, FileMode.Create);

        Saver data = new Saver(buttonHandler);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Saver LoadButtonState(ButtonTextHandler buttonHandler)
    {
        string path = Path.Combine(Application.persistentDataPath, $"buttonstate{buttonHandler.name}{SceneManager.GetActiveScene().name}.dat");

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Saver data = formatter.Deserialize(stream) as Saver;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogWarning($"No save file found at {path} for {buttonHandler.name}");
            return null;
        }
    }
}