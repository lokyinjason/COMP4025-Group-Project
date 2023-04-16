using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        // this.transform.position = pos.position;
        this.transform.rotation = pos.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // this.transform.position = pos.position;
        this.transform.rotation = pos.rotation;
    }
}