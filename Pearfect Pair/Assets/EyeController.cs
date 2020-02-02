using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    public Animator _eyeAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Blink()
    {
        _eyeAnim.SetTrigger("blink");
    }
}
