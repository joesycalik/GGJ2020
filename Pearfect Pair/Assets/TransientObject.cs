using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransientObject : MonoBehaviour
{

    [SerializeField] private float transitionDelayToTransient = 1.0f;
    [SerializeField] private float transitionDelayFromTransient = 1.0f;
    [SerializeField] private float transientAlpha = 0.1f;

    private SpriteRenderer renderer;
    private BoxCollider2D col;
    
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();

        StartCoroutine(SwitchTransience(true));
    }

    private IEnumerator SwitchTransience(bool isTransient)
    {
        if (isTransient)
        {
            yield return new WaitForSeconds(transitionDelayToTransient);
        } else {
            yield return new WaitForSeconds(transitionDelayFromTransient);
        }

        col.enabled = !isTransient;

        Color c = renderer.color;
        if (isTransient)
        {
            c.a = transientAlpha;
        } else {
            c.a = 1.0f;
        }
        renderer.color = c;

        StartCoroutine(SwitchTransience(!isTransient));
    }

}
