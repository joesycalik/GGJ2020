using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 0.5f;
    [SerializeField]
    float torque = -1f;
    [SerializeField]
    float lowGravityValue = 0.25f;

    Rigidbody2D rBody;

    bool grounded = true;
    float airTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        else if (collision.collider.gameObject.CompareTag("Edge"))
        {
            grounded = true;
        }

        if (grounded)
        {
            rBody.gravityScale = 1;
            airTime = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Edge"))
        {
            grounded = false;
            rBody.gravityScale = lowGravityValue;
            airTime = 0;
        }
    }

    private void Update()
    {
        rBody.gravityScale = Mathf.Lerp(lowGravityValue, 1, airTime);
        airTime += 0.5f * Time.deltaTime;

        if (airTime > 1.0f)
        {
            airTime = 1;
        }
    }

    float xInput = 0;
    float movementDir = 0;

    void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        movementDir = 0;
        
        movementDir = xInput;

        // Debug.Log(movementDir);

        rBody.AddForce(Vector2.right * movementDir * speed * (!grounded ? 2 : 1) + (!grounded && airTime > 0.1f && airTime < 0.2f ? Vector2.up * speed : Vector2.zero));
        rBody.AddTorque(xInput * torque);
    }

}
