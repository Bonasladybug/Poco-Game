using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcPlayer : MonoBehaviour
{
    public GameObject chat;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter () {
		chat.SetActive(true);
        
    

        

		
    }

     void OnTriggerExit () {
		chat.SetActive(false);
}
}