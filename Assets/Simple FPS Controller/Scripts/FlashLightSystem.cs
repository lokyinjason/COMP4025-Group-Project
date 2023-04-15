using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] private float batteryLife = 100f; // The battery life of the flashlight
    [SerializeField] private float maxBatteryLife = 100f; // The battery life of the flashlight
    [SerializeField] private float batteryDrain = 1f; // The amount of battery drained per second
    [SerializeField] private float maxAngle = 180f;
    [SerializeField] private float maxIntensity = 1f;
    [SerializeField] float minAngle = 40f;
    [SerializeField] private float minIntensity = 0.05f;
    [SerializeField] private float startFallOff = 75f;
    [SerializeField] private float endFallOff = 0f;
    [SerializeField] private float gameOverTimer = 5f;
    private float normalize; // normalize = (batteryLife - endFallOff) / (startFallOff - endFallOff);

    Light flashlight;

    private void Start()
    {
        flashlight = GetComponent<Light>();
    }

    private void Update()
    {
        if (batteryLife > 0){
            batteryLoss();
        }
        
        if (batteryLife >= startFallOff)
        {
            flashlight.spotAngle = maxAngle;
            flashlight.intensity = maxIntensity;
        }
        else if (batteryLife <= 0)
        {
            // Start a timer to count 30 seconds
            // When the timer is done, call the HandleGameOver() method from the GameOverHandler.cs script
            flashlight.spotAngle = 0;
            flashlight.intensity = 0;
            batteryLife = 0;
            StartCoroutine(GameOverTimer());
        }
        else if (batteryLife < endFallOff)
        {
            flashlight.spotAngle = minAngle;
            flashlight.intensity = minIntensity;
        }
        else {
            normalize = (batteryLife - endFallOff) / (startFallOff - endFallOff);
            flashlight.spotAngle = normalize * maxAngle + (1f - normalize) * minAngle;
            flashlight.intensity = normalize * maxIntensity + (1f - normalize) * minIntensity;
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

    // private void DecreaseLightAngle()
    // {
    //     if (flashlight.spotAngle <= minimumAngle)
    //         return;

    //     else
    //         flashlight.spotAngle -= angleDecay * Time.deltaTime;
    // }

    // private void DecreaseLightIntensity()
    // {
    //     flashlight.intensity -= lightDecay * Time.deltaTime;
    // }

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
        if (batteryLife > maxBatteryLife) batteryLife = 100f;
    }

    [SerializeField] float rechargeAmount = 100f; // The amount of battery life the battery provides when picked up

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
