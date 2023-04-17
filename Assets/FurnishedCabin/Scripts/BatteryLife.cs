using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryLife : MonoBehaviour
{
    [SerializeField] FlashLightSystem flashlight;
    private TextMeshProUGUI content;
    private string text = "";
    private float battery;
    private float temp;


    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<TextMeshProUGUI>();
        battery = flashlight.getBatteryLifeRemain();
        

    }

    // Update is called once per frame
    void Update()
    {
        temp = flashlight.getBatteryLifeRemain();
        if (battery != temp)
        {
            Debug.Log("entered toilet");
            battery = temp;
            text = "";
            for (int i = 0; i < battery/10; i++)
            {
                text += "|||||";
            }
            content.text = text;
        }
    }
}
