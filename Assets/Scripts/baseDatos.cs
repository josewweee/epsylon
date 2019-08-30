using UnityEngine;

[CreateAssetMenu(fileName = "baseDatos", menuName = "inventario", order = 1)]
public class baseDatos : ScriptableObject {
    [System.Serializable]
    public struct ObjetoInventario {
        public string nombre;
        public int ID;
        public Sprite icono;
    }
 public ObjetoInventario[] dataBase;
    
}
