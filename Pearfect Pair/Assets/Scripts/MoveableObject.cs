using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class MoveableObject : MonoBehaviour
{

    [SerializeField] private float mass = 1.0f;

    private Rigidbody rb;
    private BoxCollider col;
    
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
        if (GetComponent<Rigidbody>() != null)
        {
            rb = GetComponent<Rigidbody>();
        } else {
            rb = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
        }

        rb.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezeRotationX
            | RigidbodyConstraints.FreezeRotationY;

        rb.mass = mass;
    }

    private void InitializeCollider()
    {
        if (GetComponent<BoxCollider>() != null)
        {
            col = GetComponent<BoxCollider>();
        } else {
            col = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        }

        col.size = new Vector3(col.size.x, col.size.y, 1.0f);
    }

    private void FixZPosition()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
    }
}
