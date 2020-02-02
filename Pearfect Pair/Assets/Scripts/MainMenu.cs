using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame() {
        GameManager.instance.PlayGame();
    }

    public void Options() {
        //GameManager.instance.
    }

    public void Quit() {
        GameManager.instance.QuitGame();
    }
}
