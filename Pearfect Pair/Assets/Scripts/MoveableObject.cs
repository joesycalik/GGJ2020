using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class MoveableObject : MonoBehaviour
{

    [SerializeField] private float mass = 1.0f;

    private Rigidbody2D rb;
    private BoxCollider2D col;
    
    private void Start()
    {
        InitializeRigidbody();
        InitializeCollider();
        FixZPosition();
    }

    void Update()
    {
        
    }

    private void InitializeRigidbody()
    {
        if (GetComponent<Rigidbody2D>() != null)
        {
            rb = GetComponent<Rigidbody2D>();
        } else {
            rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        }

        rb.mass = mass;
    }

    private void InitializeCollider()
    {
        if (GetComponent<BoxCollider2D>() != null)
        {
            col = GetComponent<BoxCollider2D>();
        } else {
            col = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
        }

        col.size = new Vector3(col.size.x, col.size.y, 1.0f);
    }

    private void FixZPosition()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
    }
}
