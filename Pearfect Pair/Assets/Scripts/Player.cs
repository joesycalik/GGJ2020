using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 15.0f;
    [SerializeField]
    float torque = -1f;

    Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }    

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float movementDir = xInput * speed;

        rBody.AddForce(Vector3.forward * movementDir);
        rBody.AddTorque(xInput * torque);
    }

}
