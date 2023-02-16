using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Steered Cohesion")]
public class SteeredCohesionBehaviour: FilteredFlockBehaviour //was FlockBehaviour      
{

    Vector3 currentVelocity;
    public float agentSmoothTime = 0.5f;

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {

        if (context.Count == 0)
        {
            return Vector3.zero;  
        }

        Vector3 cohesionMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            cohesionMove += (Vector3)item.position;
           // Debug.Log("Steering" + item.name);//Working
        }
        cohesionMove /= context.Count;

        //create offset from agent position
        cohesionMove -= (Vector3)agent.transform.position;
        cohesionMove = Vector3.SmoothDamp(agent.transform.forward, cohesionMove, ref currentVelocity, agentSmoothTime);
        return cohesionMove;
        // throw new System.NotImplementedException();
    }

  

    public override void SetBehaviourWeight(int itt , float set)
    {
        throw new System.NotImplementedException();
    }
}
