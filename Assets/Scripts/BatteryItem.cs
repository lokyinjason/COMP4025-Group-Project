using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryItem : MonoBehaviour
{
    // [SerializeField] private float batteryLife = 50f; // The life of the battery
    [SerializeField] private float rechargeAmount = 500f; // The amount of battery life the battery provides when picked up

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Battery Recharged ");
        if (other.CompareTag("Player")) // If the battery is picked up by the player
        {
            // Debug.Log("Battery Recharged");
            FlashLightSystem flashlight = other.GetComponentInChildren<FlashLightSystem>();
            if(flashlight == null) {
                Debug.Log("Cannot find Flashlight");
                return;
            }
            Debug.Log("Flashlight found " + flashlight.name);
            flashlight.RechargeBattery(rechargeAmount); // Recharge the battery of the flashlight
            Destroy(gameObject); // Destroy the battery object
        
        }
    }
}