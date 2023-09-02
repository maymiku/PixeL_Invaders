using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class WaveScript : MonoBehaviour
{
    public GameObject nextWavePrefab;

    public GameObject textObj;
    public int numberOfEnemies;
    public int destroyedEnemies;

    private GameManager manager;

    public string DisplayText;
    // Start is called before the first frame update

    void fadeIn(){
        textObj.GetComponent<TextMeshProUGUI>().text=DisplayText;
        textObj.GetComponent<TextMeshProUGUI>().color=new Color(textObj.GetComponent<TextMeshProUGUI>().color.r, textObj.GetComponent<TextMeshProUGUI>().color.g, textObj.GetComponent<TextMeshProUGUI>().color.b, 0f);
        StartCoroutine("increaseTransp");

    }
    

    IEnumerator increaseTranspFadeIn(){
        yield return new WaitForSeconds(0.01f);
        textObj.GetComponent<TextMeshProUGUI>().color=new Color(textObj.GetComponent<TextMeshProUGUI>().color.r, textObj.GetComponent<TextMeshProUGUI>().color.g, textObj.GetComponent<TextMeshProUGUI>().color.b, textObj.GetComponent<TextMeshProUGUI>().color.a+0.05f);
        if(textObj.GetComponent<TextMeshProUGUI>().color.a<1){
            StartCoroutine("increaseTransp");
        }
        
    }
    IEnumerator increaseTransp(){
        yield return new WaitForSeconds(0.01f);
        textObj.GetComponent<TextMeshProUGUI>().color=new Color(textObj.GetComponent<TextMeshProUGUI>().color.r, textObj.GetComponent<TextMeshProUGUI>().color.g, textObj.GetComponent<TextMeshProUGUI>().color.b, textObj.GetComponent<TextMeshProUGUI>().color.a+0.05f);
        if(textObj.GetComponent<TextMeshProUGUI>().color.a<1){
            StartCoroutine("increaseTransp");
        }
        else{
            StartCoroutine("wait");
        }
    }
    IEnumerator wait(){
        yield return new WaitForSeconds(3f);
        StartCoroutine("decreaseTransp");
    }
    IEnumerator decreaseTransp(){
        yield return new WaitForSeconds(0.01f);
        textObj.GetComponent<TextMeshProUGUI>().color=new Color(textObj.GetComponent<TextMeshProUGUI>().color.r, textObj.GetComponent<TextMeshProUGUI>().color.g, textObj.GetComponent<TextMeshProUGUI>().color.b, textObj.GetComponent<TextMeshProUGUI>().color.a-0.05f);
        if(textObj.GetComponent<TextMeshProUGUI>().color.a>0){
            StartCoroutine("decreaseTransp");
        }
    }
    void waveCompleted(){
        textObj.GetComponent<TextMeshProUGUI>().text="Wave completed!";
        textObj.GetComponent<TextMeshProUGUI>().color=new Color(textObj.GetComponent<TextMeshProUGUI>().color.r, textObj.GetComponent<TextMeshProUGUI>().color.g, textObj.GetComponent<TextMeshProUGUI>().color.b, 0f);
        StartCoroutine("increaseTransp");
    }


    void Start()
    {
        manager=GameObject.Find("GameManager").GetComponent<GameManager>();
        textObj=GameObject.Find("Canvas").transform.Find("Text").gameObject;
        fadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        if(destroyedEnemies==numberOfEnemies){
            /*GameObject nextWave = Instantiate(nextWavePrefab, new Vector3(0,0,0), Quaternion.identity);
            nextWave.GetComponent<WaveScript>().textObj=this.GetComponent<WaveScript>().textObj;*/
            manager.loadNextWave();
            Destroy(gameObject);
        }
    }
}
