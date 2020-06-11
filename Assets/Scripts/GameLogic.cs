using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{

    public string input;
    public GameObject inputText;
    public GameObject guesses;

    public void AssignInput()
    {
        input = inputText.GetComponent<Text>().text;
        guesses.GetComponent<Text>().text = "You entered: " + input;
    }
}
