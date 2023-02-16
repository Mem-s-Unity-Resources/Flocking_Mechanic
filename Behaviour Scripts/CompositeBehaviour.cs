using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Composite")]

public class CompositeBehaviour : FilteredFlockBehaviour //was FlockBehaviour
{
    public FlockBehaviour[] behaviours;
    public float[] weights;
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (weights.Length != behaviours.Length) {
            Debug.LogError("Data mismatch in " + name, this);
            return Vector3.zero;
        }
        //set up move
        Vector3 move = Vector3.zero;
        //itterate through behaviour

        for (int i = 0; i < behaviours.Length; i++) {
            Vector3 partialMove = behaviours[i].CalculateMove(agent, context, flock) * weights[i];

            if (partialMove != Vector3.zero)
            {
                if (partialMove.sqrMagnitude > weights[i] * weights[i])
                {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }
                move += partialMove;
            }
        }

        return move;
    }

    public override void SetBehaviourWeight(int itt, float set) {
      //  weights[itt] = set;
        Debug.Log("Set Behaviour Weight" + behaviours[itt]+" "+ weights[itt]);
    }
}
