using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int childCount;
    public int destroyedChildCount=0;

    public GameObject blocksParent;

    public GameObject waveParent;
    public float randomMovementStrength;

    public int x=3;
    public int y=3;
    private float x_scale;
    private float y_scale;

    public float respawnDuration;
    void Start()
    {
        destroyedChildCount=0;
        StartCoroutine("moveToRandomPosition");
        x_scale=randomMovementStrength;
        y_scale=randomMovementStrength;
    }

    // Update is called once per frame

    IEnumerator moveToRandomPosition(){
        yield return new WaitForSeconds(0.2f);
        x=Random.Range(-3, 3);
        y=Random.Range(-3, 3);
        blocksParent.transform.position = new Vector3(this.transform.position.x+x_scale*x, this.transform.position.y+y_scale*y, this.transform.position.z);
        StartCoroutine("moveToRandomPosition");

    }
    void Update()
    {
        if(destroyedChildCount==childCount){
            waveParent.GetComponent<WaveScript>().destroyedEnemies+=1;
            Destroy(gameObject);
        }
        
    }
}
