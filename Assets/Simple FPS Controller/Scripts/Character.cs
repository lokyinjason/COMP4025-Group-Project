using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] FlashLightSystem flashlight;
    [SerializeField] float rechargeAmount = 500f; // The amount of battery life the battery provides when picked up
    
    // Add a public parameter of the sound effect to play when the battery is picked up
    [SerializeField] AudioSource batteryPickupSFX;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.tag == "Battery") // If the battery is picked up by the player
        {
            Debug.Log("Battery Recharged ");
            flashlight.RechargeBattery(rechargeAmount); // Recharge the battery of the flashlight
            Destroy(other.gameObject); // Destroy the battery object
        }
    }

}
