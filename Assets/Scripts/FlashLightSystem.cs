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
    
    Light flashlight;

    private void Start()
    {
        flashlight = GetComponent<Light>();
    }

    private void Update()
    {
        batteryLoss();
        if(batteryLife < 50f){
            DecreaseLightAngle();
            DecreaseLightIntensity();
        } else {
            flashlight.spotAngle = 35f;
            flashlight.intensity = 1.25f;
        }
    }

    private void DecreaseLightAngle()
    {
        if (flashlight.spotAngle <= minimumAngle)
        {
            return;
        }
        else
        {
            flashlight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }

    private void DecreaseLightIntensity()
    {
        flashlight.intensity -= lightDecay * Time.deltaTime;
    }

    private void batteryLoss(){
        if (batteryLife > 0) // If the flashlight is on and the battery still has life left
        {
            flashlight.enabled = true; // Enable the light component
            batteryLife -= batteryDrain * Time.deltaTime; // Drain the battery over time
        }
        else
        {
            flashlight.enabled = false; // Disable the light component
        }
    }

    public void RechargeBattery(float rechargeAmount)
    {
        Debug.Log("Battery Recharged by " + rechargeAmount );
        batteryLife += rechargeAmount;
    }
}