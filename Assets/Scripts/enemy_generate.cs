using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_generate : MonoBehaviour
{
    // Start is called before the first frame update
    public  List<GameObject> enemy;
    public int timeToGenerate;
    int randomtime;
    float iTime;
    public int ub=15, lb=5,blb=7,bub=10;
    public int enemycount;
    private int enemboss;
    //private static List<int> = new List<int>();
    float[] z = {1.39f, -0.71f, -2.51f, -5.06f, -8.12f, -10.79f, -13.1f, -15.67f, -18.23f, -20.43f, -23.23f};
    public float speed = 2f;


    IEnumerator generateEnemy(){
        yield return new WaitForSeconds(timeToGenerate);
        GenerateEnemy();
        StartCoroutine("generateEnemy");
    }
    void Start()
    {
        GenerateEnemy();
        enemboss=Random.Range(blb,bub);
        iTime=Time.time;
        StartCoroutine("generateEnemy");
        
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {

        /*if ((Time.time-iTime)>=timeToGenerate){
            GenerateEnemy();
            iTime=Time.time;
        }
        if(enemycount==enemboss)
        {
            GenerateEnemyBoss();
        }*/


    }

     void MoveEnemy(GameObject e){

            e.GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0, 0);

        }
        void MoveBoss(GameObject e){

            e.GetComponent<Rigidbody2D>().velocity = new Vector3(-speed/1.5f, 0, 0);

        }

    public void GenerateEnemy(){

        int n = enemy.Count;
        enemycount++;
        if(enemycount==enemboss)
        {
            GameObject enemy1 = Instantiate(enemy[7], transform.position, Quaternion.Euler(0, 0, 90));
            MoveBoss(enemy1);
            enemycount=0;
            enemboss=Random.Range(blb,bub);
        }
        else
        {
            int i = Random.Range(0, n-1);
            i=0;
        //int i = 0;
                GameObject enemy1 = Instantiate(enemy[i], transform.position, Quaternion.Euler(0, 0, 90));

        MoveEnemy(enemy1);}

        timeToGenerate = Random.Range(lb, ub);
        iTime=Time.time;

        

    }

    public void GenerateEnemyBoss(){

        GameObject enemy1 = Instantiate(enemy[7], transform.position, Quaternion.Euler(0, 0, 90));
        MoveBoss(enemy1);
    }




}
