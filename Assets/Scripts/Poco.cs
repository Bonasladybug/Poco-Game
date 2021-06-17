using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Poco : MonoBehaviour
{    
    [SerializeField] float rotationSpeed = 1;

    public NavMeshAgent agent;   

    bool isMoving = false;
    bool isWaiting = false;

    public LayerMask ground;

    Vector3 targetPosition;   
    Quaternion newPlayerRot;    

    // Start is called before the first frame update
    void Start()
    {      
        //rotation is controlled by animator
        //agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetAgentTarget();
        }

        if (isMoving == true)
        {
            updateMovement();
        }
    }

    void SetAgentTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, ground))
        {
            agent.SetDestination(hit.point);
        }
    }

    void updateMovement()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, newPlayerRot, rotationSpeed * Time.deltaTime); 

        if (transform.position == targetPosition)
        {
            isMoving = false;            
        }
    }

}
