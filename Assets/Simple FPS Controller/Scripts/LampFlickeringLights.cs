using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampFlickeringLights : MonoBehaviour
{
    [SerializeField] Light ptLight1;
    [SerializeField] Light ptLight2;
    [SerializeField] Light ptLight3;
    [SerializeField] Light ptLight4;

    // [SerializeField] MeshRenderer emissionToggle;
    [SerializeField] float maxOff = 0.5f;
    [SerializeField] float maxOn = 60f;
    [SerializeField] float onIntensity = 0.5f;
    private float randomOffTimer;
    private float randomOnTimer;


    // Start is called before the first frame update
    void Start()
    {
        // ptLight1 = GetComponent<Light>();
        // ptLight2 = GetComponent<Light>();
        // ptLight3 = GetComponent<Light>();
        // ptLight4 = GetComponent<Light>();

        // emissionToggle = GetComponent<MeshRenderer>();
        StartCoroutine(OnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator OffTimer()
    {
        // Debug.Log("Waiting to off");
        // Randomize how long to wait.
        randomOffTimer = Random.Range(0, maxOff);
        // Wait and turn it off.
        yield return new WaitForSeconds(randomOffTimer);
        // Get a reference to find the player object with a player tag
        ptLight1.intensity = 0f;
        ptLight2.intensity = 0f;
        ptLight3.intensity = 0f;
        ptLight4.intensity = 0f;

        // emissionToggle.materials[0].DisableKeyword("_EMISSION");
        // Call the timer for to turn it on.
        StartCoroutine(OnTimer());
    }

    private IEnumerator OnTimer()
    {
        // Debug.Log("Waiting to on");
        // Set how long until turning it on.
        randomOnTimer = Random.Range(0, maxOn);
        // Wait and turn it on.
        yield return new WaitForSeconds(randomOnTimer);
        // Get a reference to find the player object with a player tag
        ptLight1.intensity = onIntensity;
        ptLight2.intensity = onIntensity;
        ptLight3.intensity = onIntensity;
        ptLight4.intensity = onIntensity;

        // emissionToggle.materials[0].EnableKeyword("_EMISSION");
        // Wait and turn it on.
        StartCoroutine(OffTimer());
    }
}
