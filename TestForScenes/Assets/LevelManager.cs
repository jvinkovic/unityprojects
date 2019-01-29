using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
        Debug.Log("lev?: "+name);
    }

    public void QuitIt()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
