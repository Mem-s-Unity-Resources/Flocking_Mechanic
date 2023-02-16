using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]

public class AlignmentBehaviour : FilteredFlockBehaviour //was FlockBehaviour
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {

        if (context.Count == 0)
        {
            return agent.transform.forward;
        }

        Vector3 alignmentMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            alignmentMove += (Vector3)item.transform.forward; //or foreward?
        }
        alignmentMove /= context.Count;

        //create offset from agent position
        return alignmentMove;
        // throw new System.NotImplementedException();
    }



    public override void SetBehaviourWeight(int itt , float set)
    {
        throw new System.NotImplementedException();
    }
}
