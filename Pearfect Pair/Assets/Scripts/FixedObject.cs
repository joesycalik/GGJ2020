using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FixedObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    
    void Start()
    {
        InitializeRigidbody();
        InitializeCollider();
        FixZPosition();
    }

    // Update is called once per frame
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

        rb.constraints = RigidbodyConstraints2D.FreezePositionX
            | RigidbodyConstraints2D.FreezePositionY
            | RigidbodyConstraints2D.FreezeRotation;

        rb.isKinematic = true;
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
