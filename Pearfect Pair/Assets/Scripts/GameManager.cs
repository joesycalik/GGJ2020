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
        if (!transitioning){
            //uses the p button to pause and unpause the game
            if (Input.GetKeyDown(KeyCode.P) && (SceneManager.GetActiveScene().buildIndex != 0))
            {
                TogglePause();
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                TransitionToScene(0);
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void PlayGame()
    {
        GameSoundManager.instance.PlayClickAccept();

        TransitionToScene(1);
    }
    
	public void QuitGame()
	{
        GameSoundManager.instance.PlayClickAccept();
		Debug.Log("Quitting game!");
		Application.Quit();
	}

    public void TogglePause()
    {
        GameSoundManager.instance.PlayClickAccept();
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
        GameSoundManager.instance.PlayClickAccept();
        TransitionToScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        GameSoundManager.instance.PlayClickAccept();
        TransitionToScene(0);
    }

    private void TransitionToScene(int sceneIndex)
    {
        PauseOff();
        sceneIndexToLoad = sceneIndex;
        StartCoroutine(Transition());
    }

    bool transitioning; 

    public IEnumerator Transition()
    {
        transitioning = true;
        animator.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneIndexToLoad);

        animator.SetTrigger("FadeIn");
        transitioning = false;
    }

}
