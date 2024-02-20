using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenut : MonoBehaviour
{
    [SerializeField] GameObject pause;
    
    public void Pause() {
        pause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume() {
        pause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
    }

    public void Quit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else  
            Application.Quit();
        #endif
    }
}
