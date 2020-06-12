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
//    public GameObject guesses;
    public GameObject hint;
    public GameObject list;

    public List<int> guessArray = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        currentNumber = UnityEngine.Random.Range(1, 1000);
        guessCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentNumber);
        Debug.Log(inputNumber);
        Check();
    }

    void Check()
    {
        if (inputNumber == currentNumber)
        {
            SceneManager.LoadScene(3);
        }
        else if (guessArray.Count >= guessCount)
        {
            StartCoroutine(CustomWait());
            SceneManager.LoadScene(2);
        }
    }

    IEnumerator CustomWait()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    public void AssignInput()
    {
        input = inputText.GetComponent<Text>().text;
//        guesses.GetComponent<Text>().text = "You entered: " + input;
        inputNumber = Convert.ToInt32(input);
        guessArray.Add(inputNumber);
        list.GetComponent<TextMeshProUGUI>().text = "You entered: "; 
        foreach (int g in guessArray)
        {
            list.GetComponent<TextMeshProUGUI>().text += g + " ";
        }
        if (inputNumber > currentNumber)
            hint.GetComponent<TextMeshProUGUI>().text = "Įvestas skaičius yra didesnis už sugeneruotą";
        else if (inputNumber < currentNumber && guessArray.Count < guessCount)
        {
            hint.GetComponent<TextMeshProUGUI>().text = "Įvestas skaičius yra mažesnis už sugeneruotą";

        }
    }
}
