using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    [SerializeField] private Animator _eyeAnim;

    [SerializeField] private float blinkTimeMin = 2.0f;
    [SerializeField] private float blinkTimeMax = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        float blinkDelay = Random.Range(blinkTimeMin, blinkTimeMax);

        yield return new WaitForSeconds(blinkDelay);

        SetBlinkTrigger();
        
        StartCoroutine(Blink());
    }

    public void SetBlinkTrigger()
    {
        _eyeAnim.SetTrigger("blink");
    }
}
