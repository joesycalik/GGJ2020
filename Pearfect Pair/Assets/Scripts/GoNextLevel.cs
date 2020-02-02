using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNextLevel : MonoBehaviour
{

    public string _nextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            GameManager.instance.Reload();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.GetComponent<Player>() != null)
        {
            Debug.Log("Repete found Pete!");
            GameManager.instance.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
