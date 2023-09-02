using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text="Your run lasted "+(Math.Round(Singleton.Instance.timer, 2)).ToString()+"s";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
