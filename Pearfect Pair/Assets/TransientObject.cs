using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransientObject : MonoBehaviour
{

    [SerializeField] private float transitionDelay;
    private bool isTransient;

    private SpriteRenderer renderer;
    private BoxCollider2D col;

    private float lastTransitionTime;
    
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();

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

            Color c = renderer.color;;
            if (isTransient)
            {
                c.a = 0.0f;
            } else {
                c.a = 1.0f;
            }
            renderer.color = c;
        }
    }
}
