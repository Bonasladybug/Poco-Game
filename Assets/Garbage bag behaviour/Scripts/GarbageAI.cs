using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageAI : MonoBehaviour
{
    Animator anim;
  public GameObject player;
  public GameObject GetPlayer(){
      return player;
  }
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("distance", Vector3.Distance(transform.position,player.transform.position));
    }
}
