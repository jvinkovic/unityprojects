using System.Collections;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    int max;

    int min;

    int guess;

    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        max = 1000;

        min = 1;

        guess = 500;

        max++;

        print("---------------------------------------------------------");
        print("welcome");
        print("pick num");

        print("max is " + max);
        print("min is " + min);

        print("higher than " + guess + "?");
        print("up arrow for higher, down arrow for lower");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            print("I won!");
            StartGame();
        }
    }

    void NextGuess()
    {
        guess = (max + min) / 2;
        print("higher than " + guess + "?");
        print("up arrow for higher, down arrow for lower");
    }
}