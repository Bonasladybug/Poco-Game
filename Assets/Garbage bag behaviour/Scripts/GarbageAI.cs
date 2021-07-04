using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageAI : MonoBehaviour
{
    Animator anim;
  public GameObject player;
  public GameObject bullet;
  public GameObject turret;

  public GameObject GetPlayer(){
      return player;
  }
   void Fire(){
       GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
       b.GetComponent<Rigidbody>().AddForce(turret.transform.forward*500);
   }
   
   public void StopFiring(){
       CancelInvoke("Fire");
    
   }

   public void StartFiring(){
       InvokeRepeating("Fire",05f,0.5f);
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
