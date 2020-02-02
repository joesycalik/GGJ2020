using UnityEngine;
using System.Collections.Generic;

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

    List<GameObject> collectables;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        collectables = new List<GameObject>();
        storedPositions = new List<Vector3>();
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

        if (collision.collider.gameObject.CompareTag("Collectable"))
        {
            collision.collider.gameObject.transform.SetParent(transform);
            collision.collider.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            collectables.Add(collision.collider.gameObject);
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

    //List<Vector3> previousPositions = new List<Vector3>();
    private List<Vector3> storedPositions;

    private void Update()
    {
        //previousPositions.Add(transform.position);
        for (int i = 0; i < collectables.Count; i++)
        {
            collectables[i].transform.position = this.transform.localPosition - new Vector3(i * 5, i * 5, 0);//previousPositions[i];
        }

        storedPositions.Add(transform.position); //store the position every frame

        for (int i = 0; i < collectables.Count; i++) { 
            if (storedPositions.Count > 10)
            {
                collectables[i].transform.position = storedPositions[i * 10]; //move the player
                storedPositions.RemoveAt(0); //delete the position that player just move to
            }
        }

        //if (previousPositions.Count > 1000)
        //{
        //    List<Vector3> listCopy = previousPositions.GetRange(500, 500);
        //    previousPositions.Clear();
        //    previousPositions.AddRange(listCopy);
        //}


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

        Debug.Log(movementDir);

        rBody.AddForce(Vector2.right * movementDir * speed * (!grounded ? 2 : 1) + (!grounded && airTime > 0.1f && airTime < 0.2f ? Vector2.up * speed : Vector2.zero));
        rBody.AddTorque(xInput * torque);
    }

}
