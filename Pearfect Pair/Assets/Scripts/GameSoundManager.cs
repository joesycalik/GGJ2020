using System.Collections;
using UnityEngine;

public class GameSoundManager : MonoBehaviour
{

    public AudioSource soundFXSource;
    public AudioSource musicSource;
    public AudioClip clickAccept;
    public AudioClip click;
    public AudioClip huf;
    public AudioClip oof;
    public AudioClip sonicSpeed;
    public AudioClip squishBig;
    public AudioClip squishSmall;
    public AudioClip ugh;
    public AudioClip victory;

    private static GameSoundManager m_instance = null;
    public static GameSoundManager instance
    {
        get
        {
            if (m_instance == null)
            {
                var prefab = Resources.Load<GameObject>("GameSoundManager");
                if (prefab == null) Debug.LogError("Can't load GameSoundManager from Resources");
                var instance = Instantiate(prefab);
                if (instance == null) Debug.LogError("Instance of GameSoundManager prefab is null");
                m_instance = instance.GetComponent<GameSoundManager>();
                if (m_instance == null) Debug.LogError("No GameSoundManager found on prefab instance.");
            }
            return m_instance;
        }
    }

    public void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            DestroyObject(gameObject);
            return;
        }
        m_instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Play(AudioClip clip, float scale)
    {
        if (clip != null)
        {
            soundFXSource.PlayOneShot(clip, scale);
        }
    }

    public void PlayClickAccept()
    {
        Play(clickAccept, 1);
    }

    public void PlayClick()
    {
        Play(click, 1);
    }

    public void PlayHuf()
    {
        Play(huf, 1);
    }

    public void PlayOof()
    {
        Play(oof, 1);
    }

    public void PlaySonicSpeed()
    {
        Play(sonicSpeed, 1);

    }

    public void PlaySquishBig()
    {
        Play(squishBig, 1);
    }

    public void PlaySquishSmall()
    {
        Play(squishSmall, 1);
    }

    public void PlayUgh()
    {
        Play(ugh, 1);
    }

    public void PlayVictory()
    {
        Play(victory, 1);
    }

}