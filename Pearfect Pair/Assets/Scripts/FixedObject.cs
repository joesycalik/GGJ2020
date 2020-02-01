using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FixedObject : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider col;
    
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
        if (GetComponent<Rigidbody>() != null)
        {
            rb = GetComponent<Rigidbody>();
        } else {
            rb = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
        }

        rb.constraints = RigidbodyConstraints.FreezePositionX
            | RigidbodyConstraints.FreezePositionY
            | RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezeRotationX
            | RigidbodyConstraints.FreezeRotationY
            | RigidbodyConstraints.FreezeRotationZ;

        rb.isKinematic = true;
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
