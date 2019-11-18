using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneroPersonaje : MonoBehaviour
{

    public static string genero;

     //ESTE OBJETO NO SE DESTRUIRA EN LAS NUEVAS ESCENAS
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

   
   public void SelHombre() {
       genero = "hombre";
       StartGame.GotoStoryScene();
   }    

   public void SelMujer(){
       genero = "mujer";
       StartGame.GotoStoryScene();
   }
}
