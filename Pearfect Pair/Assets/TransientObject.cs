using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransientObject : MonoBehaviour
{

    [SerializeField] private float transitionDelay;
    [SerializeField] private bool isTransient;

    [SerializeField] private Color enabledColor;
    [SerializeField] private Color disabledColor;

    private SpriteRenderer renderer;
    private BoxCollider2D col;

    private float lastTransitionTime;
    
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
        
        renderer.color = enabledColor;

        isTransient = false;
        lastTransitionTime = Time.time;
    }

    void Update()
    {
        if ((Time.time - lastTransitionTime) >= transitionDelay)
        {
            isTransient = !isTransient;
            lastTransitionTime = Time.time;

            col.enabled = !isTransient;

            if (isTransient)
            {
                renderer.color = disabledColor;
            } else {
                renderer.color = enabledColor;
            }
        }
    }
}
