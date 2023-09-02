using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_script : MonoBehaviour
{
    // Start is called before the first frame update

    public void BackToMenu()
    {
     SceneManager.LoadScene(0); 
    }
   
   public void PlayGame(){

    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 

   }
   public void Quit()
   {
        Application.Quit();
   }

}
