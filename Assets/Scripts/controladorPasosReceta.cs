﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class controladorPasosReceta : MonoBehaviour
{
    //GENERO DEL JUGADOR
    string genero = GeneroPersonaje.genero;


    //VARIABLE GLOBAL PARA LA INSTRUCCION DE LA RECETA EN QUE ESTAMOS
    public static int instruccionActual = 0;
    public static string[] instruccionesCorrectas = new string[] {
        "heat 1 tablespoon","add onions","stir fry for 10 mins","remove","mix","add half tablespoon","add egg mixture","remove","chop","heat 1 tablespoon",
        "add meat","add carrots","stir fry 2 mins","add rice","mix","stir fry for 2 mins","add 2 tablespoon","add chooped eggs","cook for 1 min","serve"
        };

    public static string[] textosInstrucciones = new string[] {
        "heat 1 tablespoon","add onions","stir fry for 10 mins","remove","mix","add half tablespoon","add egg mixture","remove","chop","heat 1 tablespoon",
        "add meat","add carrots","stir fry 2 mins","add rice","mix","stir fry for 2 mins","add 2 tablespoon","add chooped eggs","cook for 1 min","serve"
        };

    //AUDIOS DE LA RECETAinstruccionesCorrectas
    public AudioClip a1;
    public AudioClip a2;
    public AudioClip a3;
    public AudioClip a4;
    public AudioClip a5;
    public AudioClip a6;
    public AudioClip a7;
    public AudioClip a8;
    public AudioClip a9;
    public AudioClip a10;
    public AudioClip a11;
    public AudioClip a12;
    public AudioClip a13;
    public AudioClip a14;
    public AudioClip a15;
    public AudioClip a16;
    public AudioClip a17;
    public AudioClip a18;
    public AudioClip a19;
    public AudioClip a20;
    public AudioSource audio;
    private AudioClip[] arregloAudios;
    private GameObject[] arregloBotones;
    private Text[] arregloTextos;

    public GameObject boton1;
    public GameObject boton2;
    public GameObject boton3;
    public GameObject boton4;

    public Text texto1;
    public Text texto2;
    public Text texto3;
    public Text texto4;
    void Start () {
        //ASIGNAMOS EL AUDIO DEPENDIENDO DEL GENERO.
           a1 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i1");
           a2 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i2");
           a3 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i3");
           a4 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i4");
           a5 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i5");
           a6 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i6");
           a7 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i7");
           a8 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i8");
           a9 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i9");
           a10 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i10");
           a11 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i11");
           a12 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i12");
           a13 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i13");
           a14 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i14");
           a15 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i15");
           a16 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i16");
           a17 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i17");
           a18 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i18");
           a19 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i19");
           a20 = Resources.Load<AudioClip>("Audios/lvl3/"+genero+"/i20");

        //PONEMOS AUDIOS Y BOTONES EN UN ARREGLO PARA ITERARLOS
        arregloAudios = new AudioClip[] {a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12,a13,a14,a15,a16,a17,a18,a19,a20};
        arregloBotones = new GameObject[] {boton1, boton2, boton3, boton4}; // 0 - 4
        arregloTextos = new Text[] {texto1, texto2, texto3, texto4}; // 0 - 4
        
        audio.PlayOneShot(a1);
        CambiarAccionBotones();
    }

    public void ReproducirAudio(int i){
        audio.PlayOneShot(arregloAudios[i]);
    }

    public void DetenerAudio(){
        audio.Stop();
    }

    public void CambiarAccionBotones(){
        limpiarAccionBotones();
        int i =  Random.Range(0,4);
        string instruccionCorrecta = instruccionesCorrectas[instruccionActual];
        arregloBotones[i].GetComponent<nivel3>().accionBoton = instruccionCorrecta;
        arregloTextos[i].text = textosInstrucciones[instruccionActual];
        Debug.Log("boton correcto #" + i);

        for(int j = 0; j < arregloBotones.Length; j++){
            if (j != i){
                int valorRandom = Random.Range(0,20);
                string instruccionBoton = instruccionesCorrectas[ valorRandom ];
                arregloTextos[j].text = textosInstrucciones[valorRandom];
              /*   while (instruccionBoton == instruccionCorrecta) {
                    valorRandom = Random.Range(0,20);
                    instruccionBoton = instruccionesCorrectas[ valorRandom ];
                    arregloTextos[j].text = textosInstrucciones[valorRandom];
                } */

                for (int k = 0; k < arregloBotones.Length; k++) {
                    if (j != k){
                        while (arregloTextos[j].text == arregloTextos[k].text) {
                            valorRandom = Random.Range(0,20);
                            instruccionBoton = instruccionesCorrectas[ valorRandom ];
                            arregloTextos[j].text = textosInstrucciones[valorRandom];
                        }
                    }
                }
                arregloBotones[j].GetComponent<nivel3>().accionBoton = instruccionBoton;
            }
        }
    }

    public void limpiarAccionBotones(){
        for (int i = 0; i < arregloBotones.Length; i++) {
            arregloTextos[i].text = "";
        }
    }

}
