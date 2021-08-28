using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCshooting : MonoBehaviour
{
    public GameObject NPC;
    public GameObject NPC2;
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
        Animator anim = NPC2.GetComponent<Animator>();
        if (dist < 30 && anim.GetInteger("state") !=2)
        {
            target.transform.position = NPC2.transform.position;
            sound.Play();
            StartCoroutine(ShowFire());
        }

    }

}
