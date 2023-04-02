using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;
    [SerializeField] private float batteryLife = 100f; // The battery life of the flashlight
    [SerializeField] private float batteryDrain = 1f; // The amount of battery drained per second
    [SerializeField] private float gameOverTimer = 30f;

    Light flashlight;

    private void Start()
    {
        flashlight = GetComponent<Light>();
    }

    private void Update()
    {
        batteryLoss();

        if (batteryLife < 50f)
        {
            DecreaseLightAngle();
            DecreaseLightIntensity();
        }

        if (batteryLife >= 50f)
        {
            flashlight.spotAngle = 35f;
            flashlight.intensity = 1.25f;
        }

        if (batteryLife < 0)
        {
            // Start a timer to count 30 seconds
            // When the timer is done, call the HandleGameOver() method from the GameOverHandler.cs script
            StartCoroutine(GameOverTimer());
        }
    }

    private IEnumerator GameOverTimer()
    {
        yield return new WaitForSeconds(gameOverTimer);
        // Get a reference to find the player object with a player tag
        GameObject playerObject = GameObject.FindWithTag("Player");

        // Get a reference to the GameOverHandler component on the player object
        GameOverHandler gameOverHandler = playerObject.GetComponent<GameOverHandler>();

        // Call the HandleGameOver method on the GameOverHandler component
        gameOverHandler.HandleGameOver();
    }

    private void DecreaseLightAngle()
    {
        if (flashlight.spotAngle <= minimumAngle)
            return;

        else
            flashlight.spotAngle -= angleDecay * Time.deltaTime;
    }

    private void DecreaseLightIntensity()
    {
        flashlight.intensity -= lightDecay * Time.deltaTime;
    }

    private void batteryLoss()
    {
        if (batteryLife > 0) // If the flashlight is on and the battery still has life left
        {
            flashlight.enabled = true; // Enable the light component
            batteryLife -= batteryDrain * Time.deltaTime; // Drain the battery over time
        }
        else
            flashlight.enabled = false; // Disable the light component}
    }

    public void RechargeBattery(float rechargeAmount)
    {
        Debug.Log("Battery Recharged by " + rechargeAmount);
        batteryLife += rechargeAmount;
    }

    [SerializeField] float rechargeAmount = 240f; // The amount of battery life the battery provides when picked up

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.tag == "Battery") // If the battery is picked up by the player
        {
            Debug.Log("Battery Recharged ");
            RechargeBattery(rechargeAmount); // Recharge the battery of the flashlight
            Destroy(other.gameObject); // Destroy the battery object
        }
    }
}
