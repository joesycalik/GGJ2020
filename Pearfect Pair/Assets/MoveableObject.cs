using UnityEngine;

public class MoveableObject : MonoBehaviour
{

    [SerializeField] private float mass = 1.0f;

    private Rigidbody rigidbody;
    private BoxCollider collider;
    
    private void Start()
    {
        InitializeRigidbody();
        InitializeCollider();

        transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
    }

    void Update()
    {
        
    }

    private void InitializeRigidbody()
    {
        if (GetComponent<Rigidbody>() != null)
        {
            rigidbody = GetComponent<Rigidbody>();
        } else {
            rigidbody = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
        }

        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezeRotationX
            | RigidbodyConstraints.FreezeRotationY;

        rigidbody.mass = mass;
    }

    private void InitializeCollider()
    {
        if (GetComponent<BoxCollider>() != null)
        {
            collider = GetComponent<BoxCollider>();
        } else {
            collider = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        }
    }
}
