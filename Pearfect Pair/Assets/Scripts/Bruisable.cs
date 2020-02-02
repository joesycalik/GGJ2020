using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bruisable : MonoBehaviour
{

    [SerializeField] private float health = 0.0f;

    [SerializeField] private float maxHealth = 50.0f;

    [SerializeField] private float heightDamageThreshold = 2.0f;

    private float lastHeight = float.NaN;
    
    [SerializeField] private float velocityDamageThreshold = 10.0f;

    [SerializeField] private float maxBruiseAlpha = -0.5f;

    private Renderer renderer;

    private MouthController mouth;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<Renderer>();
        mouth = GetComponent<MouthController>();

        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0.0f)
        {
            OnDeath();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        lastHeight = transform.position.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float fallHeight = ComputeFallHeight();
        float damage = ComputeFallDamageFromHeight(fallHeight);

        OnDamage(damage);
    }

    private float ComputeFallHeight()
    {
        if (float.IsNaN(lastHeight))
        {
            return 0.0f;
        }

        float diff = lastHeight - transform.position.y;
        lastHeight = transform.position.y;

        return diff;
    }

    private void OnDamage(float damage)
    {
        if (damage > 0)
        {
            Debug.Log("Damage: " + damage);
        }

        health -= damage;

        float bruiseAlpha = (maxHealth - health) / maxHealth * maxBruiseAlpha;
        renderer.material.SetFloat("_OverlayAlpha", Mathf.Clamp(bruiseAlpha, maxBruiseAlpha, 0.0f));

        mouth.SetHurtness(Mathf.Clamp(1 - health / maxHealth, 0.0f, 1.0f));

        if (health <= 0.0f)
        {
            OnDeath();
        }


    }

    private void OnDeath()
    {
        // TODO: Handle death
    }

    private float ComputeFallDamageFromVelocity(float vel)
    {
        if (vel >= velocityDamageThreshold)
        {
            Debug.Log("Relative velocity: " + vel);
            return Mathf.Pow(vel - velocityDamageThreshold, 2);
        }
        return 0.0f;
    }

    private float ComputeFallDamageFromHeight(float height)
    {
        if (height >= heightDamageThreshold)
        {
            Debug.Log("Height: " + height);
            return Mathf.Pow(height - heightDamageThreshold, 2);
        }
        return 0.0f;
    }
}
