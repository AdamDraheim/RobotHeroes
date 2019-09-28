using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pauses the level. Attach to the pause menu gameObject
/// </summary>

public class MenuPauser : MonoBehaviour
{
    public GameObject m_MenuObject;

    private bool m_IsPaused = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    public void TogglePause()
    {
        m_IsPaused = !m_IsPaused;

        //Send an on paused message to all gameobjects and monobehaviors
        var objs = FindObjectsOfType<MonoBehaviour>();

        foreach (var go in objs)
        {
            if (m_IsPaused)
                go.SendMessage("OnGamePaused", SendMessageOptions.DontRequireReceiver);
            else
                go.SendMessage("OnGameUnpaused", SendMessageOptions.DontRequireReceiver);
        }

        if (m_IsPaused)
        {
            Time.timeScale = 0;

            m_MenuObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;

            m_MenuObject.SetActive(false);
        }
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
        #else
         Application.Quit();
        #endif
    }
}
