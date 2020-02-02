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

    public Animator animator;

    private int sceneIndexToLoad;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
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

    public void PlayGame()
    {
        TransitionToScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
	public void QuitGame ()
	{
		Debug.Log("Quitting game!");
		Application.Quit();
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

    public void LoadLevel(int sceneIndex)
    {
        TransitionToScene(sceneIndex);
    }

    public void Reload()
    {
        TransitionToScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        TransitionToScene(0);
    }

    private void TransitionToScene(int sceneIndex)
    {
        sceneIndexToLoad = sceneIndex;
        StartCoroutine(Transition());
    }

    public IEnumerator Transition()
    {
        animator.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1);

        PauseOff();
        SceneManager.LoadScene(sceneIndexToLoad);

        animator.SetTrigger("FadeIn");
        
    }

}
