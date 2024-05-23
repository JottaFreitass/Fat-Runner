using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject mouseItem;
   

    public void DragItem( GameObject button )
    {
        mouseItem = button;
        mouseItem.transform.position = Input.mousePosition;
    }

    public void DropItem( GameObject button)
    {
        Transform aux = mouseItem.transform.parent;
        mouseItem.transform.SetParent(button.transform.parent);
        button.transform.SetParent(aux);
    }
}