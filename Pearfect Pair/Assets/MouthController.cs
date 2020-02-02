using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthController : MonoBehaviour
{

    public Animator _mouthAnim;
    public float _hurtness;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _hurtness = Mathf.Clamp( _hurtness, 0, .99f);
        _mouthAnim.Play("repetePear_HappytoHurt_Mouth", 0, _hurtness);
    }
}
