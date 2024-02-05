using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGameButton() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else  
            Application.Quit();
        #endif
    }

    public void CreditsGameButton() {
        SceneManager.LoadScene("Credits");
    }

    public void ExitToGameOver() {
        SceneManager.LoadScene("GameOver");
    }
}
