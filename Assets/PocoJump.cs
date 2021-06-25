using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocoJump : MonoBehaviour
{
   public void StartJump(){
       transform.LeanMoveLocal(new Vector2(1,53), 1).setEaseOutQuart().setLoopPingPong();
   }
}
