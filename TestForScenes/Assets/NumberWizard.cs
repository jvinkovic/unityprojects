using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour
{
    public Text text;

    int max;

    int min;

    int guess;

    public int MaxGuesses = 5;

    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        max = 1000;

        min = 1;

        

        max++;

        guess = Random.Range(min, max);

        text.text = guess + "?";
    }



    public void GuessHigher()
    {
        max = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        min = guess;
        NextGuess();
    }

    void NextGuess()
    {
        guess = Random.Range(min, max); 

        

        MaxGuesses--;

        if (MaxGuesses <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
        else
        {

            text.text = guess + "?";
        }
    }
}