using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
      //inputField = GameObject.Find("Player Name Input Field").InputField;
      MenuHandler.Instance.playerName = inputField.text;
      //playerName = inputField.text;
      //textDisplay.GetComponent<Text>().text = "Welcome " + playerName;
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

}
