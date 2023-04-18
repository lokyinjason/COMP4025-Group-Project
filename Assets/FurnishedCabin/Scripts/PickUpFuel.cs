using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFuel : MonoBehaviour
{
    public GameObject FuelOB;
    public GameObject invFuelOB;
    public GameObject pickUpText;
    public AudioSource pickUpSound;

    public bool inReach;

    [SerializeField] ObjectivesContent obj;


    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        invFuelOB.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("In Trigger Collision");

        if (other.gameObject.tag == "Reach")
        {
            Debug.Log("In Reach Trigger Collision");
            inReach = true;
            pickUpText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);

        }
    }


    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            FuelOB.SetActive(false);
            pickUpSound.Play();
            invFuelOB.SetActive(true);
            pickUpText.SetActive(false);
            // obj.setContent("next");
        }

        
    }
}
