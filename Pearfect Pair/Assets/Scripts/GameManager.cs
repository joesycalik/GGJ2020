using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject pauseMenuObject;

    [SerializeField] private int score;

    [SerializeField] private GameObject transitionOverlay;

    [SerializeField] private float transitionDelay;

    private Color transitionColor;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        transitionColor = transitionOverlay.GetComponent<Image>().color;
    }

    private void Update()
    {
        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.instance.TogglePause();
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void TogglePause()
    {
        if (Time.timeScale == 1)
        {
            PauseOn();
        } else if (Time.timeScale == 0) {
            PauseOff();
        }
    }

    public void PauseOn()
    {
        Time.timeScale = 0;
        pauseMenuObject.SetActive(true);
    }

    public void PauseOff()
    {
        Time.timeScale = 1;
        pauseMenuObject.SetActive(false);
    }

    public void LoadLevel(string level)
    {
        TransitionToScene(level);
    }

    public void Reload()
    {
        TransitionToScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        TransitionToScene("MainMenu");
    }

    private void TransitionToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        PauseOff();
    }

}
