using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVFlickeringLight : MonoBehaviour
{
    [SerializeField] GameObject tvBody;
    [SerializeField] Light ptLight;
    [SerializeField] MeshRenderer emissionToggle;
    [SerializeField] float maxOff = 0.5f;
    [SerializeField] float maxOn = 1f;
    [SerializeField] float onIntensity = 0.5f;
    private float randomOffTimer;
    private float randomOnTimer;

    void Start()
    {
        emissionToggle = GetComponent<MeshRenderer>();
        StartCoroutine(OnTimer());
    }

    void Update()
    {
        
    }

    private IEnumerator OffTimer()
    {
        // Debug.Log("Waiting to off");
        randomOffTimer = Random.Range(0, maxOff);
        yield return new WaitForSeconds(randomOffTimer);
        ptLight.intensity = 0f;
        
        // Turn off the MeshRenderer texture 
        emissionToggle.enabled=false;

        emissionToggle.materials[0].DisableKeyword("_EMISSION");
        yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds before calling OnTimer
        StartCoroutine(OnTimer());
    }

    private IEnumerator OnTimer()
    {
        // Debug.Log("Waiting to on");
        randomOnTimer = Random.Range(0, maxOn);
        yield return new WaitForSeconds(randomOnTimer);
        
        ptLight.intensity = onIntensity;
        emissionToggle.enabled=true;

        emissionToggle.materials[0].EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds before calling OffTimer
        StartCoroutine(OffTimer());
    }
}