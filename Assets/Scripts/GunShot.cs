using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GunShot : MonoBehaviour
{
    private LineRenderer lr;
    public GameObject muzzleEnd;
    public GameObject target;
    public GameObject aCamera;
    public GameObject aGun;
    private AudioSource sound;
    public GameObject NPC;
    private Animator anim;
    public GameObject GunOnHand;

    public GameObject NPC2;
    public GameObject GunOnHand2;
    private Animator anim2;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        sound = aGun.GetComponent<AudioSource>();
        anim = NPC.GetComponent<Animator>();
        anim2 = NPC2.GetComponent<Animator>();
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
        if (Input.GetButtonDown("space"))
        {
            RaycastHit hit;
            if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit)){
                target.transform.position = hit.point;
                StartCoroutine(DrawShot());

                //NPC was shot
                if(NPC.transform.gameObject.name == hit.transform.gameObject.name)
                {
                    anim.SetInteger("state",2);
                    NPC.GetComponent<NavMeshAgent>().enabled = false; //stop moving.
                    LineRenderer tmp = NPC.GetComponent<LineRenderer>();
                    tmp.positionCount = 0;
                    if (GunOnHand.activeSelf)
                    {
                        GunOnHand.SetActive(false);
                    }
                }

                //NPC2 was shot
                if (NPC2.transform.gameObject.name == hit.transform.gameObject.name)
                {
                    anim2.SetInteger("state", 2);
                    NPC2.GetComponent<NavMeshAgent>().enabled = false; //stop moving.
                    LineRenderer tmp = NPC2.GetComponent<LineRenderer>();
                    tmp.positionCount = 0;
                    if (GunOnHand2.activeSelf)
                    {
                        GunOnHand2.SetActive(false);
                    }
                }
            }
        }
    }
}
