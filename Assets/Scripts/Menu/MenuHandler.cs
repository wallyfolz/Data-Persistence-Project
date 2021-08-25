using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public static string playerName;
    public GameObject inputField;
    public GameObject textDisplay;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EditName()
    {
        playerName = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Welcome " + playerName;


    }
}
