using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] indicatorObjects;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateIndicator(int bulletCount){
        for(int i = 0; i < indicatorObjects.Length; i++){
            if(i+1<=bulletCount){
                indicatorObjects[i].SetActive(true);
            }
            else{
                indicatorObjects[i].SetActive(false);
            }
        }
    }
}
