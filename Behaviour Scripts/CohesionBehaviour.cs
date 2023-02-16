using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Flock/Behaviour/Cohesion")]
public class CohesionBehaviour : FilteredFlockBehaviour //was FlockBehaviour
{

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock) {

        if (context.Count == 0) {
            return Vector3.zero;
        }

        Vector3 cohesionMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            cohesionMove += (Vector3)item.position;
        }
        cohesionMove /= context.Count;

        //create offset from agent position
        cohesionMove -= (Vector3)agent.transform.position;
        return cohesionMove;
        // throw new System.NotImplementedException();
    }


    public override void SetBehaviourWeight(int itt , float set)
    {
        throw new System.NotImplementedException();
    }
}
