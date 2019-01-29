﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name); 
    }

    public void QuitIt()
    {
        Application.Quit();
      
    }

    public void LoadNewLevel()
    {
        Brick.breakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNewLevel();
        }
    }

}
