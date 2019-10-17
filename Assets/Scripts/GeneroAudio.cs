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
        audio = GetComponent<AudioSource>();
        if (genero == "hombre"){
            audio.PlayOneShot(audioHombre);
        }else{
            audio.PlayOneShot(audioMujer);
        }
        
    }
}
