using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsulePlayer : MonoBehaviour
{


    public float movespeed;
    public float rotatespeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,Input.GetAxis("Vertical")* Time.deltaTime *movespeed);
        transform.Rotate(0,Input.GetAxis("Horizontal")* Time.deltaTime * rotatespeed,0 );
    }
}
