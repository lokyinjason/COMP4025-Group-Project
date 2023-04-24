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

    public bool firstLock;
    public bool firstOpen;
    [SerializeField] ObjectivesContent obj;

    void Start()
    {
        inReach = false;
        hasKey = false;
        unlocked = false;
        locked = true;
        firstLock = true;
        firstOpen = true;
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
            if (firstOpen)
            {
                obj.removeContent("Use the key to unlock something. ");
                obj.removeContent("Find the key to open the fuse box. ");
                firstOpen = false;
            }
            if (fuseBox.GetBool("isClose_Obj_1"))
            {
                BoxOpens();
                openText.SetActive(false);
            }
        }

        if (locked && inReach && Input.GetButtonDown("Interact"))
        {
            lockedSound.Play();

            if (firstLock)
            {
                obj.setContent("Find the key to open the fuse box. ");
            }
            firstLock = false;
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
        // Debug.Log("It Closes");
        // fuseBox.SetBool("isOpen_Obj_1", false);
        // fuseBox.SetBool("isClose_Obj_1", true);

        // closeBoxSound.Play();

        // door.SetBool("Closed", true);
    }


}
