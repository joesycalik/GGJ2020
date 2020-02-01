using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerHeight : MonoBehaviour
{
    public Transform target;
    public float _followSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, _followSpeed * Time.deltaTime);
    }
}
