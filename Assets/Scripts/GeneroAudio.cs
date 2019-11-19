using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneroAudio : MonoBehaviour
{
   
    public AudioClip audioHombre;
    public AudioClip audioMujer;
    string genero = GeneroPersonaje.genero;
    public new AudioSource audio;

    void Start()
    {

        //audioHombre = Resources.Load<AudioClip>("Audios/introduccion/introduccionHombre.mp3");
        //audioMujer = Resources.Load<AudioClip>("Audios/introduccion/introMujer.mp3");
        audio = GetComponent<AudioSource>();
        /* audio = GetComponent<AudioSource>(); */
        ReproducirAudio();
    }

    public void ReproducirAudio(){
        Debug.Log("valor del genero = " + genero);
        if (genero == "hombre"){
            audio.PlayOneShot(audioHombre);
        }else{
            Debug.Log(audioMujer);
            audio.PlayOneShot(audioMujer);
        }
    }
}
