using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance{get; private set;}

        // public int SceneID;
        public float timer;

    private void Awake()
    {
        if(Instance==null)
        {
            Instance= this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(Instance!=this)
            {
                Destroy(gameObject);
            }
        }
        
    }

    // Start is called before the first frame update
    
}
