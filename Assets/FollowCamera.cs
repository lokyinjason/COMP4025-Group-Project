using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform pos;
    [SerializeField] Vector3 addZ = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        // this.transform.position = pos.position;
        this.transform.rotation = pos.rotation;
        this.transform.position = pos.position;
    }

    // Update is called once per frame
    void Update()
    {
        // this.transform.position = pos.position;
        this.transform.rotation = pos.rotation;
        this.transform.position = pos.position + addZ;
    }
}