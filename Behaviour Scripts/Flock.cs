using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{

    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();

    public FlockBehaviour behaviour;
    [Header("Behaviour Params")]


    [Range(10, 500)]
    public int startingcount = 250;
    public float AgentDesinity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;

    [Range(1f, 100f)]
    public float maxSpeed = 10f;

    [Range(0f, 10f)]
    public float avoidanceRadiusMultiplier = 10f;
    [Range(0.0f, 10.0f)]
    public float neighbourRadius = 0.5f;
    public bool showNeighbourRaidus = true;
    public GameObject flocktarget;

    public float squareMaxSpeed;
    public float squareNeightbourRadius;
    public float squareAvoidanceRadius=1.0f;//default of 1, if starting with 0 sets the calculate in start to 0

    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }
    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed; //squared function?
        squareNeightbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = /*squareAvoidanceRadius */ avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
        for (int i = 9; i < startingcount; i++)
        {
            Vector3 startingPosition = flocktarget.transform.position + (Random.insideUnitSphere * startingcount * AgentDesinity);

            FlockAgent newAgent = Instantiate(
                agentPrefab,
                new Vector3(startingPosition.x,0, startingPosition.z),
               Quaternion.Euler(Vector3.up * Random.Range(0f, 360f)),
               transform //Parameter response for what?
                );
            newAgent.name = "Agent" + i; //Rename to raindeer
            newAgent.Initialise(this); //FlockAgent script acess to flock's collider
            newAgent.AssignTargetPosition(flocktarget);
            agents.Add(newAgent);

        }
      //  behaviour.SetBehaviourWeight(3,0.5f);
       // Debug.Log("Behaviour Params"+ );

    }

    // Update is called once per frame
    void Update()
    {
        foreach (FlockAgent agent in agents)
        {
            List<Transform> context = GetNearByObjects(agent);
            //FOR DEBUG ONLY
         //  agent.GetComponentInChildren<Renderer>().material.color = Color.Lerp(Color.white, Color.red, context.Count / 6f);
            Vector3 move = behaviour.CalculateMove(agent, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;

            }
            agent.Move(move);
        }

    }

    List<Transform> GetNearByObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighbourRadius);
        foreach (Collider c in contextColliders)
        {
            if (c != agent.agentCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }

 

    void OnDrawGizmos()
    {
        if (showNeighbourRaidus)
        {

            foreach (FlockAgent agent in agents)
            {
                // Draw a yellow sphere at the transform's position
                Gizmos.color = new Color(0.0f, 0.2f, 0.4f, 0.3f);
                Gizmos.DrawSphere(agent.transform.position, neighbourRadius);

            }
        }
    }
}

