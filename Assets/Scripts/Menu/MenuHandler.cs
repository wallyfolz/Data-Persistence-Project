using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuHandler : MonoBehaviour
{
    public static MenuHandler Instance;
    public string playerName;
    public int publicHighScore;
    public string publicHighPlayer;

    private void Awake()
    {
        if(Instance != null)
        {
          Destroy(gameObject);
          return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

  [System.Serializable]
    class SaveData
    {
        public string publicHighPlayer;
        public int publicHighScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.publicHighPlayer = publicHighPlayer;
        data.publicHighScore = publicHighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            publicHighPlayer = data.publicHighPlayer;
            publicHighScore = data.publicHighScore;
        }
    }

}
