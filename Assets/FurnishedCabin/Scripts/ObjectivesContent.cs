using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectivesContent : MonoBehaviour
{
    private TextMeshPro content;

    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setContent(string newText)
    {
        content.text = newText;
    }
}
