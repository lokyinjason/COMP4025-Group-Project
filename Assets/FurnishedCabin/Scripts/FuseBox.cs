using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    public Animator fuseBox;
    public GameObject openText;
    public GameObject KeyINV;

    public AudioSource openBoxSound;
    public AudioSource closeBoxSound;
    public AudioSource lockedSound;

    public bool inReach;
    public bool unlocked;
    public bool locked;
    public bool hasKey;

    void Start()
    {
        inReach = false;
        hasKey = false;
        unlocked = false;
        locked = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            Debug.Log("In Reach");
            inReach = true;
            openText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            Debug.Log("Out of Reach");
            inReach = false;
            openText.SetActive(false);
        }
    }



    void Update()
    {
        if(KeyINV.activeInHierarchy)
        {
            locked = false;
            hasKey = true;
        } else {
            hasKey = false;
        }

        if (hasKey && inReach && Input.GetButtonDown("Interact"))
        {
            if (fuseBox.GetBool("isClose_Obj_1"))
            {
                BoxOpens();
            }
            else 
            {
                BoxCloses();
            }
        }

        if (locked && inReach && Input.GetButtonDown("Interact"))
        {
            lockedSound.Play();
        }




    }
    void BoxOpens ()
    {
        Debug.Log("It Opens");

        fuseBox.SetBool("isOpen_Obj_1", true);
        fuseBox.SetBool("isClose_Obj_1", false);
  
        //Let the fuseBox's collider be false
        fuseBox.GetComponent<BoxCollider>().enabled = false;
        
        openBoxSound.Play();

    }

    void BoxCloses()
    {
        Debug.Log("It Closes");
        fuseBox.SetBool("isOpen_Obj_1", false);
        fuseBox.SetBool("isClose_Obj_1", true);

        closeBoxSound.Play();

        // door.SetBool("Closed", true);
    }


}
