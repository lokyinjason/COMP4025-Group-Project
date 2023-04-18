using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOutLight : MonoBehaviour
{
    public int index;
    private LightsOutPuzzle puzzle;
    public bool inReach;
    public GameObject openText;
    public AudioSource clickSound;

    // Start is called before the first frame update
    void Start()
    {
        puzzle = transform.parent.GetComponent<LightsOutPuzzle>();
        inReach = false;
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

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            Debug.Log("Toggle light " + index);
            clickSound.Play();
            puzzle.OnLightClick(index);
        }
    }
}
