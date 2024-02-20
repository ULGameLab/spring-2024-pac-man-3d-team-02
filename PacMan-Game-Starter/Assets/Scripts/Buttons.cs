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

    //Onclick function to quit game
    public void QuitGameButton() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else  
            Application.Quit();
        #endif
    }

    //Onclick function to go to credits screen
    public void CreditsGameButton() {
        SceneManager.LoadScene("Credits");
    }

    //Onclick function to go to start screen
    public void ToStartScreen() {
        SceneManager.LoadScene("StartScreen");
    }

    //Onclick function to go to button credits screen
    public void ToButtonCreditsScreen() {
        SceneManager.LoadScene("ButtonCredits");
    }

    //Onclick function to go to background credits screen
    public void ToBakgroundCreditsScreen() {
        SceneManager.LoadScene("BackgroundCredits");
    }

    public void ToBarsCreditsScreen() {
        SceneManager.LoadScene("BarsCredits");
    }

    public void ToCreatorsScreen() {
        SceneManager.LoadScene("Creators");
    }

    public void ToMainGame() {
        SceneManager.LoadScene("Main Game");
    }
}
