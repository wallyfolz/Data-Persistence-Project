using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class LoadStartMenu : MonoBehaviour
{
    public InputField inputField;

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void EditName()
    {
      MenuHandler.Instance.playerName = inputField.text;
      inputField.text = "";
    }

    public void Exit()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }

    [System.Serializable]
    public class SaveData
    {
        public string publicHighPlayer;
        public int publicHighScore;
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.publicHighPlayer = MenuHandler.Instance.publicHighPlayer;
        data.publicHighScore = MenuHandler.Instance.publicHighScore;

        string json = JsonUtility.ToJson(data);

        Debug.Log(json);
        Debug.Log(Application.persistentDataPath);

        File.WriteAllText(Application.persistentDataPath + "/savefile2.json",json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile2.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            MenuHandler.Instance.publicHighPlayer = data.publicHighPlayer;
            MenuHandler.Instance.publicHighScore = data.publicHighScore;
        }
    }


}
