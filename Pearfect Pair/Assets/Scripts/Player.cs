using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    float speed = 15.0f;

    void Update()
    {
        var xDir = Input.GetAxis("Horizontal");
        var translation = Input.GetAxis("Horizontal") * speed;

        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(Vector3.forward * translation);
        rigidbody.AddTorque(-xDir * 1f);
    }

}
