using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Stay In Radius")]
public class StayInRadiusBehaviour : FlockBehaviour
{
    public Vector3 center;
    public float radius = 15f;
    public bool showRadius = true;
   
   // public Transform target; //to calculate the center of radius, this will alternatively move the flock
    //we can also adjust the size of the radius to create a scatering and gathering effect
    //Ultimately, we will have to assign Canvas UI buttons or input keys to manupilate these settings ?? should this be done though Flock.cs??
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
        center = agent.targetPosition != null ? agent.targetPosition.transform.position : Vector3.zero;
        Vector3 centerOffset = center - (Vector3)agent.transform.position;

        float t = centerOffset.magnitude / radius; //if t is 0 we're at the center if t is 1 we're at the edge
       // Debug.Log(this.name+":"+ t);
        if (t < 0.9f) 
        {
            return Vector3.zero; //if we're within 10% to the edge of the radius....

        }
        
        
        if (showRadius&& agent.targetPosition.TryGetComponent<Gizmo>(out Gizmo gizmo))
        {
            gizmo.size = radius;
        }

        return centerOffset * t * t;


        }

    public override void SetBehaviourWeight(int itt , float set)
    {
        throw new System.NotImplementedException();
    }
}
