using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransientObject : MonoBehaviour
{

    [SerializeField] private float transitionDelayToTransient = 3.0f;
    [SerializeField] private float transitionDelayFromTransient = 1.0f;
    [SerializeField] private float transientAlpha = 0.1f;

    [SerializeField] private float warningStart = 1.0f;
    [SerializeField] private float warningDuration = 0.2f;
    [SerializeField] private float warningAlpha = 0.5f;

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
        Color c;
        if (isTransient)
        {
            yield return new WaitForSeconds(transitionDelayToTransient - warningStart);

            c = renderer.color;
            c.a = warningAlpha;
            renderer.color = c;

            yield return new WaitForSeconds(warningDuration);
            
            c = renderer.color;
            c.a = 1.0f;
            renderer.color = c;

            yield return new WaitForSeconds(warningStart - warningDuration);
        } else {
            yield return new WaitForSeconds(transitionDelayFromTransient);
        }

        col.enabled = !isTransient;

        c = renderer.color;
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
