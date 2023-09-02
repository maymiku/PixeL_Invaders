using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static float timer;
    public bool gameRunning=true;
    void Start()
    {
        timer=0;
        this.GetComponent<TextMeshProUGUI>().text="Time Elapsed: 0.00";
    }

    // Update is called once per frame
    void Update()
    {
        if(gameRunning){
            timer+=Time.deltaTime;
            //Singleton.Instance.timer=timer;
            gameObject.GetComponent<TextMeshProUGUI>().text="Time Elapsed: " + (Math.Round(timer, 2)).ToString();
        }
    }
}
