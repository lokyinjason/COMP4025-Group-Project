﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public GameObject keyOB;
    public GameObject invOB;
    [SerializeField] GameObject pickUpText;
    public AudioSource keySound;

    public bool inReach;

    [SerializeField] ObjectivesContent obj;


    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        invOB.SetActive(false);
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
            keyOB.SetActive(false);
            keySound.Play();
            invOB.SetActive(true);
            pickUpText.SetActive(false);
            // obj.setContent("next");

            obj.setContent("Use the key to unlock something. ");
        }

        
    }
}
