using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    public GameObject mouseItem;
    public Item[] item;

    public void DragItem( GameObject button )
    {
        mouseItem = button;
        mouseItem.transform.position = Input.mousePosition;
    }

    public void DropItem( GameObject button)
    {
        if(mouseItem != null)
        {
            if(button.name.Equals("Drop"))
            {
                int pos = int.Parse(mouseItem.name);
                Instantiate(item[pos].prefab, Vector3.zero, Quaternion.identity);
            }
            else
            {
                Transform aux = mouseItem.transform.parent;
                mouseItem.transform.SetParent(button.transform.parent);
                button.transform.SetParent(aux);
            }
        }
    }
}