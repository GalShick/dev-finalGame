using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerMotion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject aCamera;
    public GameObject CrossHair; // regular
    public GameObject CrossHairTouch; // the trigger (this) is touched
    private bool isTriggerHit;
    private Animator anim;

    private bool isClosed;
    void Start()
    {
        //the animator is a property of a parent object
        anim = this.gameObject.transform.parent.GetComponent<Animator>();
        isClosed = true;
        isTriggerHit = false;
    }

/*    private void OnMouseDown()
    {
        anim.SetBool("open",isClosed);
        isClosed = !isClosed;
    }
*/

    // Update is called once per frame
   void Update()
    {
        RaycastHit hit;
        // casts ray from camera towards forward direction and writes down to hit (OUT)
        // the info of GameObject that was hit by this ray
        if(Physics.Raycast(aCamera.transform.position,aCamera.transform.forward,out hit))
        {
            // check if THIS is the GameObject that was hit
            if (hit.transform.gameObject.name == this.gameObject.name && hit.distance < 15) //we are close enough exchange crosshairs
            {
                if (!isTriggerHit)
                {
                    isTriggerHit = true;
                    CrossHair.SetActive(false); // turns crosshair off
                    CrossHairTouch.SetActive(true); //turns crosshair on
                }

                if(Input.GetButtonDown("OpenCloseBtn")) // we have defined SPACE as TouchBtn  
                {
                    anim.SetBool("open", isClosed);

                    isClosed = !isClosed;
                }

            }
            else // we didn't hit the trigger
            {
                if (isTriggerHit)
                {
                    isTriggerHit = false;
                    CrossHair.SetActive(true); // turns crosshair on
                    CrossHairTouch.SetActive(false); //turns crosshair off
                }
            }
            
        }
    }
}