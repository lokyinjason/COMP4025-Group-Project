using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Animator door;
    public GameObject openText;

    public AudioSource openDoorSound;
    public AudioSource closeDoorSound;

    public bool inReach;

    void Start()
    {
        inReach = false;
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

        if (inReach && Input.GetButtonDown("Interact"))
        {
            if (door.GetBool("isClose_Obj_1"))
            {
                DoorOpens();
            }
            else 
            {
                DoorCloses();
            }
        }
    }

    void DoorOpens ()
    {
        Debug.Log("It Opens");
        // door.SetBool("Open", true);
        // door.SetBool("Closed", false);
        door.SetBool("isOpen_Obj_1", true);
        door.SetBool("isClose_Obj_1", false);

        openDoorSound.Play();

    }

    void DoorCloses()
    {
        Debug.Log("It Closes");
        door.SetBool("isOpen_Obj_1", false);
        door.SetBool("isClose_Obj_1", true);

        closeDoorSound.Play();

        // door.SetBool("Closed", true);
    }


}
