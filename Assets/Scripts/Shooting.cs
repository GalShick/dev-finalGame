using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject aCamera;
    public GameObject target;

    public GameObject muzzle;

    private LineRenderer aLine;

    private AudioSource sound;
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
        if(Input.GetButtonDown("OpenCloseBtn")) //fire
        {
            RaycastHit hit;
            if(Physics.Raycast(aCamera.transform.position,aCamera.transform.forward,out hit))
            {
                target.transform.position = hit.point;
                sound.Play();
                StartCoroutine(ShowFire());
            }
        }   
    }
}
