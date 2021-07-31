using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mudPositionComponent : MonoBehaviour
{
    public bool isPlanted = false;
   
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponentInParent<Inventory>().Mudarea = this.gameObject;        
    }
}
