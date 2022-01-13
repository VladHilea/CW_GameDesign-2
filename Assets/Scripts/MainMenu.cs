using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene("Day1");
    }
    public void ExitGame()
    {
        Debug.Log("Quitting game..");
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
