using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Avoidance")]

public class AvoidanceBehaviour : FilteredFlockBehaviour //was FlockBehaviour           
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbors, return no adjustment
        if (context.Count == 0)
        {
            return Vector3.zero;
        }
        //add all points together and average
        Vector3 avoidanceMove = Vector3.zero;
        int nAvoid = 0;

        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            // Debug.Log("Avoiding" + item.name+" SqrMag:"+ Vector3.SqrMagnitude(item.position - agent.transform.position)+" SqrAvoidRad:" + flock.squareAvoidanceRadius); //Not firing!!
            int colType = item.GetComponent<Collider>() is CapsuleCollider ? 1 : 0;
            float avoidRadModifier = colType == 1 ? item.GetComponent<CapsuleCollider>().radius:0;
            Vector3 avoidArea = colType == 0 ? item.GetComponent<BoxCollider>().size : Vector3.zero;
           
           // Debug.Log("Avoiding" + item.name+" colType"+ colType+ " avoidRadModifier:"+ avoidRadModifier+ " avoidArea:"+ avoidArea); //Not firing!!


            if (colType==1 && Vector3.SqrMagnitude(item.position - agent.transform.position) < flock.squareAvoidanceRadius+(avoidRadModifier * avoidRadModifier))
            {
                nAvoid++;
                avoidanceMove += (Vector3)(agent.transform.position - item.position);
            }
            if (colType == 0 && (Mathf.Pow(item.position.x - agent.transform.position.x,2f) < flock.squareAvoidanceRadius + (avoidArea.x * avoidArea.x))|| (Mathf.Pow(item.position.z - agent.transform.position.z, 2f) < flock.squareAvoidanceRadius + (avoidArea.z * avoidArea.z)))
            {
                nAvoid++;
                avoidanceMove += (Vector3)(agent.transform.position - item.position);
            }
            //   if(Vector3.Distance(PlayerObject.transform.position,new Vector3(3,2,2)) < Distance || Vector3.Distance(PlayerObject.transform.position,new Vector3(3,2,2)) == Distance)

        }

        if (nAvoid > 0)
        {
            avoidanceMove /= nAvoid;
        }
            return avoidanceMove;
            // throw new System.NotImplementedException();
        
    }
    public override void SetBehaviourWeight(int itt = 0, float set=0f)
    {
        throw new System.NotImplementedException();
    }
}
