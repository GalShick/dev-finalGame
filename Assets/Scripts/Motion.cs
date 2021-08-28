using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Motion : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 2f;
    private float angularSpeed = 1f;
    private float rx = 0f, ry;
    public GameObject playerCamera; // public allows to init this object from unity
    // Start is called before the first frame update
    private AudioSource footStep;

    public GameObject NPC;
    public GameObject NPC2;
    public GameObject NPC3;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        footStep = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx, dz;

        // simple motion
        // transform.Translate(new Vector3(0, 0, 0.1f));

        // mouse input
        rx -= Input.GetAxis("Mouse Y") * angularSpeed; //vertical rotation
        playerCamera.transform.localEulerAngles = new Vector3(rx,0,0); // runs on playCamera
        ry = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * angularSpeed; // horizontal rotation
        transform.localEulerAngles = new Vector3(0, ry, 0);

        // keyboard input
        dx = Input.GetAxis("Horizontal") * speed;
        dz = Input.GetAxis("Vertical") * speed;
        if (dx != 0 || dz != 0)
            {
            Vector3 motion = new Vector3(dx, -1, dz);
            motion = transform.TransformDirection(motion); // now in Global coordinates
            controller.Move(motion);
        
            //foot step sound
            if(!footStep.isPlaying && controller.velocity.magnitude>0.1)
            {
                 footStep.Play();
            }

            //if NPC was idle, set it to running
            NavMeshAgent nma = NPC.GetComponent<NavMeshAgent>();
            Animator an = NPC.GetComponent<Animator>();
            if(!nma.enabled)
            {
                nma.enabled = true;
            }
            if(an.GetInteger("state")==1) //idle
            {
                an.SetInteger("state",3);
            }


            //if NPC2 was idle, set it to running
            NavMeshAgent nma2 = NPC2.GetComponent<NavMeshAgent>();
            Animator an2 = NPC2.GetComponent<Animator>();
            if (!nma2.enabled)
            {
                nma2.enabled = true;
            }
            if (an2.GetInteger("state") == 1) //idle
            {
                an2.SetInteger("state", 3);
            }

            //if NPC2 was idle, set it to running
            NavMeshAgent nma3 = NPC3.GetComponent<NavMeshAgent>();
            Animator an3 = NPC3.GetComponent<Animator>();
            if (!nma3.enabled)
            {
                nma3.enabled = true;
            }
            if (an3.GetInteger("state") == 1) //idle
            {
                an3.SetInteger("state", 3);
            }
        }
        
    }
}