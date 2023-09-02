using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Rigidbody2D rb;
    public Weapon weapon;
    public Transform transform;

    private bool buttonHeld;
    private float aimAngle;
    private float x;
    private float turnSpeed=2f;
    private bool bulletFired=false;

    private float waitDuration=0.1f;

    private int bulletCount=0;
    private int maxBulletCount=8;
    Vector2 moveDirection;
    Vector2 mousePosition;

    public GameObject ammoObj;
    private AmmoDisplay ammoScript;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ammoScript=ammoObj.GetComponent<AmmoDisplay>();
    }

IEnumerator changeBulletFired(){
    yield return new WaitForSeconds(waitDuration);
    bulletFired=false;
}

IEnumerator resetBulletCount(){
    yield return new WaitForSeconds(1f);
    bulletCount=0;
    ammoScript.updateIndicator(8-bulletCount);
}

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButton(0))
        {
            buttonHeld=true;
            if(!bulletFired && bulletCount<maxBulletCount){
                weapon.Fire();
                bulletFired=true;
                bulletCount+=1;
                ammoScript.updateIndicator(8-bulletCount);
                audioSource.Play();
                StartCoroutine("changeBulletFired");
                //Debug.Log(bulletCount);
            }
            /*else if(bulletCount==maxBulletCount){
                StartCoroutine("resetBulletCount");
                bulletCount+=1;
            }*/
            
        }
        else{
            if(bulletCount==maxBulletCount){
                StartCoroutine("resetBulletCount");
                bulletCount+=1;
            }
            buttonHeld=false;
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    private void FixedUpdate()
    {
        // rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        /*if (buttonHeld==false){
            x+=turnSpeed;
        }
        aimAngle=x%280;
        if (aimAngle>=140){
            aimAngle=280-aimAngle-70;
        }
        else{
            aimAngle=aimAngle-70;
        }

        if(x==2800){
            x=0;
        }*/
        if (aimAngle > 85f)
        {
            aimAngle = 85f;
        }
        if (aimAngle < -85f)
        {
            aimAngle = -85f;
        }


        transform.rotation = Quaternion.Euler(0f,0f, aimAngle);
    }



}
