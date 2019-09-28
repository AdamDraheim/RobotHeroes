using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string mapToLoad;

    public void StartGame()
    {
        SceneManager.LoadScene(mapToLoad);
        GameControl.gameControl.Reset();
    }

    public void QuitGame()
    {
        Application.Quit(0);
    }
}
