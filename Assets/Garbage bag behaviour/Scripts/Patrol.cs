using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : NPCBaseFSM
{ 
    
    GameObject[]  waypoints;
    int currentWP;

    void Awake(){
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
    base.OnStateEnter(animator,stateInfo, layerIndex);
    currentWP = 0 ;

    }
     
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
     
     if (waypoints.Length == 0) return;
     if (Vector3.Distance(waypoints[currentWP].transform.position,NPC.transform.position) < accurancy)
     {
         currentWP++;
         if(currentWP >= waypoints.Length)
         {
             currentWP = 0;
         }
     }

     var direction = waypoints[currentWP].transform.position - NPC.transform.position;
     NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation,Quaternion.LookRotation(direction),rotSpeed * Time.deltaTime);
     NPC.transform.Translate(0,0, Time.deltaTime * speed);
    }
   

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){

    }
}
