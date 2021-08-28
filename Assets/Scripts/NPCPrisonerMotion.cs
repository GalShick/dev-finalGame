using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPrisonerMotion : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    public GameObject obj;
    private LineRenderer lr;

    public GameObject GunOnHand;
    // Start is called before the first frame update

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 0;
        agent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(agent.enabled){
            //print(player.name);
            agent.SetDestination(player.transform.position); //the path has been computed
            lr.positionCount = agent.path.corners.Length;
            for(int i=0;i<agent.path.corners.Length; i++)
                lr.SetPosition(i, agent.path.corners[i]);
        }
        */

        if (agent.enabled && !GunOnHand.activeSelf)
        {
            //print(player.name);
            agent.SetDestination(obj.transform.position); //the path has been computed
            lr.positionCount = agent.path.corners.Length;
            for (int i = 0; i < agent.path.corners.Length; i++)
                lr.SetPosition(i, agent.path.corners[i]);
        }
        else if(GunOnHand.activeSelf)
        {
            agent.SetDestination(player.transform.position); //the path has been computed
            lr.positionCount = agent.path.corners.Length;
            for (int i = 0; i < agent.path.corners.Length; i++)
                lr.SetPosition(i, agent.path.corners[i]);


        }

    }
}
