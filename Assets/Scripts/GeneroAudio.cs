using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneroAudio : MonoBehaviour
{
   
    public AudioClip audioHombre;
    public AudioClip audioMujer;
    string genero = GeneroPersonaje.genero;
    public AudioSource audio;

    void Start()
    {

        audioHombre = Resources.Load<AudioClip>("Audios/introduccion/introduccionHombre");
        audioMujer = Resources.Load<AudioClip>("Audios/introduccion/introMujer");

        audio = GetComponent<AudioSource>();
       /*  if (genero == "hombre"){
            audio.PlayOneShot(audioHombre);
        }else{ */
        Debug.Log(audioMujer);
            audio.PlayOneShot(audioMujer);
        //}
        
    }
}
