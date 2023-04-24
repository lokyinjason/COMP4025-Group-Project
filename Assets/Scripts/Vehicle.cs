using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public GameObject openText;
    public AudioSource failIgnitionSound;
    public AudioSource startIgnitionSound;
    public GameObject fuelINV;
    
    public bool inReach;
    public bool hasFuel;

    void Start()
    {
        inReach = false;
        hasFuel = false;
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
        if(fuelINV.activeInHierarchy)
        {
            // locked = false;
            hasFuel = true;
        } else {
            hasFuel = false;
        }

        if (inReach && Input.GetButtonDown("Interact"))
        {
            if (hasFuel)
            {
                Debug.Log("Starting Vehicle");
                startIgnitionSound.Play();

                StartCoroutine(death());
            } else {
                Debug.Log("No Fuel");
                failIgnitionSound.Play();
            }
        }
    }

    IEnumerator death() {
        yield return new WaitForSeconds(2f);
        
        GameOverHandler gameOverHandler = GetComponent<GameOverHandler>();
        gameOverHandler.HandleGameOver();
    }


}
