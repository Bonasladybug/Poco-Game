using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityStandardAssets.Characters.ThirdPerson;

public class playerController : MonoBehaviour
{
    //Simple Singleton Pattern
    public static playerController instance;    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of playerController");
        }
        instance = this;
    }

    //navigation variables
    public NavMeshAgent agent;
    private Transform target;
    public LayerMask ground;

    //interaction variables
    public Interactable focus;
    public ThirdPersonCharacter character;
    public bool inDialogue = false;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //rotation is controlled by animator
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (target != null && inDialogue == false)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
        
        if (Input.GetMouseButton(0) && inDialogue == false)
        {  
            SetAgentTarget();
            checkInteractable();
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }            
    }
    void SetAgentTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, ground) && !EventSystem.current.IsPointerOverGameObject())
        {
            agent.SetDestination(hit.point);
            RemoveFocus();
        }
    }

    void checkInteractable()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100) && !EventSystem.current.IsPointerOverGameObject())
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                SetFocus(interactable);
            }
        }        
    }

    void SetFocus(Interactable newFocus)
    {
        //check if we had another focus before and deactivate previous one
        if (newFocus != focus)
        {
            if (focus != null) 
                focus.OnDeFocused();

            focus = newFocus;
            FollowTarget(newFocus);
        }
        focus = newFocus;
        newFocus.OnFocused(transform);        
        FollowTarget(newFocus);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDeFocused();

        focus = null;
        StopFollowTarget();
    }    

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * 0.8f;
        agent.updateRotation = false;

        target = newTarget.interactionTransform;       
    }
    public void StopFollowTarget( )
    {
        agent.stoppingDistance = 0.5f;
        agent.updateRotation = true;

        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }
}
