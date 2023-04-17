using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private TextMeshProUGUI title;
    private TextMeshProUGUI content;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        title = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        content = gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void changeDialogueState(bool state)
    {
        this.gameObject.SetActive(state);
    }

    public void changeDialogueTitle(string newTitle)
    {
        title.text = newTitle;
    }

    public void changeDialogueContent(string newContent)
    {
        content.text = newContent;
    }
}
