using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_guider : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> waypoints;

    public float vel_ = 4f;

    private float distance_threshold = 0.01f;
    int i =0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, waypoints[i].transform.position, vel_ * Time.deltaTime);

        if(Vector3.Distance(transform.position,  waypoints[i].transform.position) < distance_threshold){
            if(i<waypoints.Count -1){
                i++;
            }
        }

    }
}
