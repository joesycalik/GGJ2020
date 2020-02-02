using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject pauseMenuObject;

    [SerializeField] private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else {
            Destroy(this);
        }
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
            Time.timeScale = 0;
            pauseMenuObject.SetActive(true);
        } else if (Time.timeScale == 0) {
            Time.timeScale = 1;
            pauseMenuObject.SetActive(false);
        }
    }

    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
        Time.timeScale = 1;
    }

    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

}
