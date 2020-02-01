using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private Camera camera;

    [SerializeField] private float xSpeed = 2.0f;
    [SerializeField] private float ySpeed = 2.0f;

    [SerializeField] private float size = 5.0f;
    [SerializeField] private float maxSizeScale = 2.0f;
    [SerializeField] private float distanceScale = 0.1f;

    void Start()
    {
        camera = Camera.main;
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float newX = Mathf.Lerp(transform.position.x, target.position.x, xSpeed * Time.deltaTime);
        float newY = Mathf.Lerp(transform.position.y, target.position.y, ySpeed * Time.deltaTime);
        transform.position = new Vector3(newX, newY, transform.position.z);

        Vector2 diff = (target.position - transform.position) * distanceScale;
        camera.orthographicSize = Mathf.Lerp(size, maxSizeScale * size, diff.magnitude);
    }
}
