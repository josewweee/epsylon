using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BaseDatos", menuName = "Inventario/lista" , order = 1)]
public class BaseDatos : ScriptableObject
{
    [System.Serializable]

    public struct itemInventario
    {
        public string nombre;
        public int ID;
        public int precio;
        public Sprite icono;
        public Tipo tipo;
         public string descripcion;
    }

    public enum  Tipo
    {
        Fruta,
        Verdura,
        Condimento,
        Liquido
    }

    public itemInventario[] baseDatos;

}
