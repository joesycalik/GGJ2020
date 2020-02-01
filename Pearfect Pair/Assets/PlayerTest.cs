using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{

    [SerializeField]
    private float speed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position += Vector3.right * speed * Input.GetAxis("Horizontal");
    }
}
