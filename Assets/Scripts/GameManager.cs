using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public  GameObject[] waveObjects;

    private  int index=0;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    public  void loadNextWave(){
        index+=1;
        if(index==waveObjects.Length){
            SceneManager.LoadScene("GameOver");
        }
        GameObject nextWave = Instantiate(waveObjects[index], new Vector3(0,0,0), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
