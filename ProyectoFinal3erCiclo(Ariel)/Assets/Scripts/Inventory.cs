using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ListaInventadaPropia<GameObject> safeObjects;
    private void OnEnable()
    {
        safeObjects = new ListaInventadaPropia<GameObject>();
    }

    public void SaveObject(GameObject obj)
    {
        safeObjects.InsertNodeAtEnd(obj);
        Debug.Log("Objeto guardado: " + obj.name);
    }
}
