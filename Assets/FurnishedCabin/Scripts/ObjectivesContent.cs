using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectivesContent : MonoBehaviour
{
    private TextMeshProUGUI content;
    private List<string> objList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<TextMeshProUGUI>();
        objList.Add("Find the gasoline. ");
    }

    // Update is called once per frame
    void Update()
    {
        content.text = "";
        foreach (string obj in objList)
        {
            content.text = content.text + "\n" + obj;
        }
    }

    public void setContent(string newText)
    {
        //content.text = newText;
        objList.Add(newText);
    }

    public void removeContent(string oldText)
    {
        foreach (string obj in objList)
        {
            if (string.Equals(obj,oldText))
            {
                objList.Remove(obj);
            }
        }
    }

    //public string getContent()
    //{
    //    return content.text;
    //}
}
