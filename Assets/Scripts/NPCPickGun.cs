using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPickGun : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gunToPick;
    public GameObject gunInHand;

    public GameObject NPC;

    private Animator anim;
    void Start()
    {
        anim = NPC.GetComponent<Animator>();
        print("started");
    }

    // Update is called once per frame
    void Update()
    {
        var dist = Vector3.Distance(gunToPick.transform.position, NPC.transform.position);
        if (dist < 10)
        {
            anim.SetInteger("state", 4);
            gunToPick.SetActive(false);
            gunInHand.SetActive(true);

        }
    }
}
