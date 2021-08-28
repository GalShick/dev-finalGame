using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonerMotion : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("z")) //death
        {
            anim.SetInteger("state",2);
        }
        else if(Input.GetKey("x")) // running
        {
             anim.SetInteger("state",3);
        }
        else if(Input.GetKey("c")) // idle
        {
             anim.SetInteger("state",1);
        }
        else // none
            anim.SetInteger("state",1);
    }
}
