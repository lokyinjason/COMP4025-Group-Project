using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLights : MonoBehaviour
{
    [SerializeField] Light ptLight;
    [SerializeField] MeshRenderer emissionToggle;
    [SerializeField] float maxOff = 0.5f;
    [SerializeField] float maxOn = 60f;
    [SerializeField] float onIntensity = 0.5f;
    private float randomOffTimer;
    private float randomOnTimer;


    // Start is called before the first frame update
    void Start()
    {
        ptLight = GetComponent<Light>();
        emissionToggle = GetComponent<MeshRenderer>();
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
        ptLight.intensity = 0f;
        emissionToggle.materials[0].DisableKeyword("_EMISSION");
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
        ptLight.intensity = onIntensity;
        emissionToggle.materials[0].EnableKeyword("_EMISSION");
        // Wait and turn it on.
        StartCoroutine(OffTimer());
    }
}
