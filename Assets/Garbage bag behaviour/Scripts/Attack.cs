using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : NPCBaseFSM {



    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
     HealthMonitor.HealthValue -= 1;
     base.OnStateEnter(animator, stateInfo, layerIndex);
     NPC.GetComponent<GarbageAI>().StartFiring();
     
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
     NPC.transform.LookAt(opponent.transform.position);
    }
    

   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
    NPC.GetComponent<GarbageAI>().StopFiring();
   }
   
}
