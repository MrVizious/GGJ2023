using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void LoadMainMenuScene() {
        SceneManager.LoadScene(0);
    }

    public void LoadCreditScene() {
        SceneManager.LoadScene(2);
    }

    public void LoadControlsScene() {
        SceneManager.LoadScene(3);
    }

     public void LoadGameScene() {
        SceneManager.LoadScene(1);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
