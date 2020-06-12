using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public int currentNumber;
    public int guessCount;
    public int inputNumber = 0;

    public string input;
    public GameObject inputText;
    public GameObject hint;
    public GameObject list;
    public GameObject remaining;

    public List<int> guessArray = new List<int>();

    void Start()
    {
        currentNumber = UnityEngine.Random.Range(1, 1000);
    }

    void Update()
    {
        Check();
        remaining.GetComponent<TextMeshProUGUI>().text = "Liko: " + (guessCount - guessArray.Count);
    }

    void Check()
    {
        if (inputNumber == currentNumber)
        {
            SceneManager.LoadScene(3);
        }
        else if (guessArray.Count >= guessCount)
        {
            StartCoroutine(Wait(5));
            SceneManager.LoadScene(2);
        }
    }

    static IEnumerator Wait(int t)
    {
        yield return new WaitForSeconds(t);
    }

    public void AssignInput()
    {
        input = inputText.GetComponent<Text>().text;
        inputNumber = Convert.ToInt32(input);
        guessArray.Add(inputNumber);

        Print();
        
        if (inputNumber > currentNumber)
            hint.GetComponent<TextMeshProUGUI>().text = "Įvestas skaičius yra didesnis už sugeneruotą";
        else if (inputNumber < currentNumber && guessArray.Count < guessCount)
            hint.GetComponent<TextMeshProUGUI>().text = "Įvestas skaičius yra mažesnis už sugeneruotą";
    }

    private void Print()
    {
        list.GetComponent<TextMeshProUGUI>().text = "Bandymai: ";
        foreach (int g in guessArray)
        {
            list.GetComponent<TextMeshProUGUI>().text += g + " ";
        }
    }
}
