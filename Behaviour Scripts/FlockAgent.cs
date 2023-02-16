using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlockAgent : MonoBehaviour
{
    public Flock agentFlock; //will this be used?
   
    public Collider agentCollider;
    public GameObject targetPosition; //target of movement
    public float yDisplacement = 0f;
    Vector3 currRotationVelocity;
   // public Collider AgentCollider; //{ get { return AgentCollider; } }
    public void Initialise(Flock flock=null)
    {
        agentCollider = GetComponent<Collider>();
        if (flock != null) 
        {
            agentFlock = flock;
        }
        
    //    Debug.Log(this.name + " " + GetComponent<Collider>());
    }

    public void AssignTargetPosition(GameObject target)
    {
        targetPosition = target;
    }


    public void Move(Vector3 velocity) {    

       // transform.forward = new Vector3(velocity.x,yDisplacement,velocity.z); //original
       transform.forward= Vector3.SmoothDamp(transform.forward, new Vector3(velocity.x, yDisplacement, velocity.z), ref currRotationVelocity, 0.1f); //last param is rotation is, stops the agents from trembling
        transform.position += new Vector3(velocity.x,yDisplacement, velocity.z) * Time.deltaTime;

    }
}
