using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] FlashLightSystem flashlight;
    [SerializeField] float rechargeAmount = 500f; // The amount of battery life the battery provides when picked up
    
    // Add a public parameter of the sound effect to play when the battery is picked up
    [SerializeField] AudioSource batteryPickupSFX;

    [SerializeField] BackgroundMusic bgMusic;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.tag == "Battery") // If the battery is picked up by the player
        {
            Debug.Log("Battery Recharged ");
            flashlight.RechargeBattery(rechargeAmount); // Recharge the battery of the flashlight
            Destroy(other.gameObject); // Destroy the battery object

        }
        else if (other.tag == "Toilet") // if the player enter toilet
        {
            Debug.Log("entered toilet");
            bgMusic.changeBGM(bgMusic.toiletMusic);
        }
        else if (other.tag == "LivingRoom") // if the player enter toilet
        {
            bgMusic.changeBGM(bgMusic.livingrmMusic);
        }
        else if (other.tag == "Enemy") // if the player touch enemy
        {
            Rigidbody rigidBody = GetComponent<Rigidbody>();
            rigidBody.constraints = RigidbodyConstraints.FreezePosition;
            StartCoroutine(death());
        }
    }

    IEnumerator death() {
        yield return new WaitForSeconds(3.75f);
        
        GameOverHandler gameOverHandler = GetComponent<GameOverHandler>();
        gameOverHandler.HandleGameOver();
    }

}
