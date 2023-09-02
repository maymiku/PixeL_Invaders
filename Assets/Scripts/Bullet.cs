using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioSource audio1;
    public AudioSource audio2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collider has a "wall" tag
        if(collision.gameObject.CompareTag("reflectingWall")){
            audio1.Play();
        }
        if (collision.gameObject.CompareTag("wall"))
        {
            // Destroy the bullet gameObject
            Destroy(gameObject);
        }
    }
}