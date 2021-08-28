using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMotion : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    private LineRenderer lr;

    public GameObject GunOnHand;
    public GameObject NPC;
    // Start is called before the first frame update

    private AudioSource sound;
    private Animator anim;
    public GameObject muzzleEnd;
    public GameObject target;
    public GameObject NPC2;
    public GameObject GunOnHand2;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 0;
        agent.enabled = false;
        anim = NPC.GetComponent<Animator>();
        sound = GunOnHand.GetComponent<AudioSource>();
    }


    IEnumerator DrawShot()
    {
        lr.SetPosition(0, muzzleEnd.transform.position);
        lr.SetPosition(1, target.transform.position);
        sound.Play();
        lr.enabled = true;
        yield return new WaitForSeconds(0.1f);
        lr.enabled = false;
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
            agent.SetDestination(player.transform.position); //the path has been computed
            lr.positionCount = agent.path.corners.Length;
            for (int i = 0; i < agent.path.corners.Length; i++)
                lr.SetPosition(i, agent.path.corners[i]);
        }
        else if(GunOnHand.activeSelf)
        {
            agent.SetDestination(NPC.transform.position); //the path has been computed
            lr.positionCount = agent.path.corners.Length;
            for (int i = 0; i < agent.path.corners.Length; i++)
                lr.SetPosition(i, agent.path.corners[i]);

            var dist = Vector3.Distance(NPC.transform.position, NPC2.transform.position);
            if (dist < 30)
            {
                anim.SetInteger("state", 2);
                NPC.GetComponent<NavMeshAgent>().enabled = false; //stop moving.
                LineRenderer tmp = NPC.GetComponent<LineRenderer>();
                tmp.positionCount = 0;
                if (GunOnHand2.activeSelf)
                {
                    GunOnHand2.SetActive(false);
                }
            }

        }

    }
}
