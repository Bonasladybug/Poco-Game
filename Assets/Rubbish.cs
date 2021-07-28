using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubbish : MonoBehaviour
{

    public GameObject opponent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var direction = opponent.transform.position - this.transform.position;
        Debug.Log("distance" + direction.z);
    }
}
