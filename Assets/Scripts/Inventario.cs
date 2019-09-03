using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventario : MonoBehaviour
{
    [System.Serializable]
    public struct itemInvetarioId
    {
        public int id;
        public int cantidad;

        public itemInvetarioId(int id, int cantidad)
        {
            this.id = id;
            this.cantidad = cantidad;
        }
    }

    [SerializeField]
    BaseDatos datos;
    public GraphicRaycaster rayo;
    private PointerEventData pointerData;
    private List<RaycastResult> resulRayo;
    public Transform canvas;
    public GameObject itemSelec;
    public Transform exPadre;
    public static GameObject descripcion;
    public int OSC;
    public int OSID;
    public Transform contenido;
    public Item item;
    public List<itemInvetarioId> inventario = new List<itemInvetarioId>();

    // Start is called before the first frame update
    void Start()
    {
        ActualizarInventario();
        pointerData = new PointerEventData(null);
        resulRayo = new List<RaycastResult>();
    }

    // Update is called once per frame
    void Update()
    {
        Arrastrar();
    }

    void Arrastrar()
    {

        if (Input.GetMouseButtonDown(0))
        {
            pointerData.position = Input.mousePosition;
            rayo.Raycast(pointerData, resulRayo);
            if (resulRayo.Count > 0 && resulRayo[0].gameObject.GetComponent<Item>())
            {
                itemSelec = resulRayo[0].gameObject;
                exPadre = itemSelec.transform.parent.transform;
                exPadre.GetComponent<Image>().fillCenter = false;
                itemSelec.transform.SetParent(canvas);
            }
        }

        if (itemSelec != null)
        {
            itemSelec.GetComponent<RectTransform>().localPosition = panCanvas(Input.mousePosition);
        }
        if (itemSelec != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                pointerData.position = Input.mousePosition;
                resulRayo.Clear();
                rayo.Raycast(pointerData, resulRayo);
                if (resulRayo.Count > 0)
                {
                    foreach (var resultado in resulRayo)
                    {
                        if (resultado.gameObject.tag == "Slot")
                        {
                            if (resultado.gameObject.GetComponentInChildren<Item>() == null)
                            {
                                itemSelec.transform.SetParent(resultado.gameObject.transform);
                                itemSelec.transform.localPosition = Vector2.zero;
                                exPadre = itemSelec.transform.parent.transform;
                            }
                            else
                            {
                                if (resultado.gameObject.GetComponentInChildren<Item>().ID == 
                                itemSelec.GetComponent<Item>().ID)
                                {
                                    resultado.gameObject.GetComponentInChildren<Item>().cantidad += 
                                    itemSelec.GetComponent<Item>().cantidad;
                                    Destroy(itemSelec.gameObject);
                                }
                                else
                                {
                                    itemSelec.transform.SetParent(exPadre.transform);
                                    itemSelec.transform.localPosition = Vector2.zero;
                                }
                            }
                        }
                        else
                        {
                            itemSelec.transform.SetParent(exPadre.transform);
                            itemSelec.transform.localPosition = Vector2.zero;
                        }
                    }
                }
                itemSelec = null;
            }
        }
        resulRayo.Clear();
    }

    public Vector2 panCanvas(Vector2 posicionPan)
    {
        Vector2 viewportPonit = Camera.main.ScreenToViewportPoint(posicionPan);
        Vector2 canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;
        return (new Vector2(viewportPonit.x * canvasSize.x, viewportPonit.y * canvasSize.y)
                - canvasSize / 2);
    }

    public void Agregar(int id, int cantidad)
    {
        for (int i = 0; i < inventario.Count; i++)
        {
            if (inventario[i].id == id)
            {
                inventario[i] = new itemInvetarioId(id, inventario[i].cantidad + cantidad);
                ActualizarInventario();
                return;
            }
        }

        inventario.Add(new itemInvetarioId(id, cantidad));
        ActualizarInventario();

    }

    List<Item> pool = new List<Item>();
    public void ActualizarInventario()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (i < inventario.Count)
            {
                itemInvetarioId inv = inventario[i];
                pool[i].ID = inv.id;
                pool[i].GetComponent<Image>().sprite = datos.baseDatos[inv.id].icono;
                pool[i].GetComponent<RectTransform>().localPosition = Vector2.zero;
                pool[i].cantidad = inv.cantidad;
                pool[i].gameObject.SetActive(true);
            }
            else
            {
                pool[i].gameObject.SetActive(false);
                pool[i].gameObject.transform.GetComponent<Image>().fillCenter = false;
            }
        }
        if (inventario.Count > pool.Count)
        {
            for (int i = pool.Count; i < inventario.Count; i++)
            {
                Item it = Instantiate(item, contenido.GetChild(i));
                pool.Add(it);
                if (contenido.GetChild(0).childCount >= 2)
                {
                    for (int t = 0; t < contenido.childCount; t++)
                    {
                        if (contenido.GetChild(t).childCount == 0)
                        {
                            it.transform.SetParent(contenido.GetChild(t));
                            break;
                        }
                    }
                }
                it.transform.position = Vector2.zero;
                it.transform.localScale = Vector2.one;
                itemInvetarioId inv = inventario[i];
                pool[i].ID = inv.id;
                pool[i].GetComponent<Image>().sprite = datos.baseDatos[inv.id].icono;
                pool[i].GetComponent<RectTransform>().localPosition = Vector2.zero;
                pool[i].cantidad = inv.cantidad;
                pool[i].gameObject.SetActive(true);
            }
        }
    }
}

