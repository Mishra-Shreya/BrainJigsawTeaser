using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuScript_ : MonoBehaviour
{

    public string URL;
    
    public void Home()
    {
        //PlayerPrefs.SetInt("Level", LevelNumber);
        SceneManager.LoadScene("MainMenu");
    }

    public void Levels()
    {
        //PlayerPrefs.SetInt("Level", LevelNumber);
        SceneManager.LoadScene("Levels");
    }

    public void QuitBJT ()
    {
        Debug.Log("Quit App!");
        Application.OpenURL(URL);
        //Application.Quit();
    }

    public void EASY()
    {
        //PlayerPrefs.SetInt("Level", LevelNumber);
        SceneManager.LoadScene("Gameeasy");
    }

    public void iNTERMEDIATE()
    {
        //PlayerPrefs.SetInt("Level", LevelNumber);
        SceneManager.LoadScene("GameInt");
    }

    public void ADVANCED()
    {
        //PlayerPrefs.SetInt("Level", LevelNumber);
        SceneManager.LoadScene("Gameadv");
    }

    public void EXPERT()
    {
        //PlayerPrefs.SetInt("Level", LevelNumber);
        SceneManager.LoadScene("Game");
    }
}
