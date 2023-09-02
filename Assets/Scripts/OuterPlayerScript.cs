using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OuterPlayerScript : MonoBehaviour
{
    private float respawnDuration;

    public GameObject OuterParent;
    
    private float timeElapsed=0f;

    private AudioSource audioSource;

    public AudioClip audioClip;
    IEnumerator reactivate(){
        yield return new WaitForSeconds(respawnDuration);
        GetComponent<SpriteRenderer>().enabled=true;
        GetComponent<SpriteRenderer>().color= new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 1f);
        //GetComponent<Rigidbody2D>().isKinematic=false;
        gameObject.layer=0;
        OuterParent.GetComponent<ParentScript>().destroyedChildCount-=1;
    }

    IEnumerator changeTransp(){
        yield return new WaitForSeconds(0.1f);

        timeElapsed+=0.1f;
        if(respawnDuration-timeElapsed<1f && GetComponent<SpriteRenderer>().color.a!=1f){
            Debug.Log("Out here");
            GetComponent<SpriteRenderer>().color= new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 0.1f-GetComponent<SpriteRenderer>().color.a);
            StartCoroutine("changeTransp");
        }
        else if(GetComponent<SpriteRenderer>().color.a!=1f){
            StartCoroutine("changeTransp");
        }
        //GetComponent<SpriteRenderer>().color= new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, GetComponent<SpriteRenderer>().color.a + (0.6f * 0.1f/respawnDuration));
        /*GetComponent<SpriteRenderer>().color= new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, GetComponent<SpriteRenderer>().color.a + (0.6f * 0.1f/respawnDuration));
        if(GetComponent<SpriteRenderer>().color.a>=1){
            GetComponent<SpriteRenderer>().color=new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 1f);
        }*/
    }

    

    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("Here new");
        if (collision.gameObject.CompareTag("bullet"))
        {
            OuterParent.GetComponent<ParentScript>().destroyedChildCount+=1;

            Destroy(collision.gameObject);
            gameObject.layer=7;
            //GetComponent<SpriteRenderer>().enabled=false;
            GetComponent<SpriteRenderer>().color= new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 0.1f);
            timeElapsed=0f;
            audioSource.Play();
            StartCoroutine("changeTransp");
            //GetComponent<Rigidbody2D>().isKinematic=true;
            StartCoroutine("reactivate");
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        
        respawnDuration = OuterParent.GetComponent<ParentScript>().respawnDuration;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
