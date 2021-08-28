using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PrisonerShooting : MonoBehaviour
{
    public GameObject NPC;
    public GameObject NPC2;
    public GameObject NPC3;
    public GameObject target;

    public GameObject muzzle;

    private LineRenderer aLine;

    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        aLine = GetComponent<LineRenderer>();
        sound = GetComponent<AudioSource>();
    }

    IEnumerator ShowFire()
    {
        aLine.SetPosition(0, muzzle.transform.position); //first point
        aLine.SetPosition(1, target.transform.position); //second point
        aLine.enabled = true;
        //do something before the delay
        yield return new WaitForSeconds(0.1f);
        //do something after delay
        aLine.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        var dist = Vector3.Distance(NPC.transform.position, NPC2.transform.position);
        var dist2 = Vector3.Distance(NPC.transform.position, NPC3.transform.position);
        Animator anim1 = NPC2.GetComponent<Animator>();
        Animator anim2 = NPC3.GetComponent<Animator>();
        if (dist < 30 && anim1.GetInteger("state") != 2)
        {
            target.transform.position = NPC2.transform.position;
            sound.Play();
            StartCoroutine(ShowFire());
        }
        else if (dist2 < 30 && anim2.GetInteger("state") != 2)
        {
            target.transform.position = NPC3.transform.position;
            sound.Play();
            StartCoroutine(ShowFire());
        }

    }
}
