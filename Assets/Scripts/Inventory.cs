using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    public GameObject mouseItem;
    public Item[] item;
    
    public Camera mainCamera;
    [SerializeField]
    //public Rigidbody2D Rigidbody_item;
   
   

    
    public void DragItem(GameObject button)
    {
        mouseItem = button;
        mouseItem.transform.position = Input.mousePosition;
    }

    public void DropItem(GameObject button)
    {
        if (mouseItem != null)
        {
            if (button.name.Equals("Drop"))
            {
                int pos = int.Parse(mouseItem.name);
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 10.0f;
                Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
               
                Instantiate(item[pos].prefab, worldPosition, Quaternion.identity);
                //caindo(Rigidbody_item);
            }
            else
            {
                Transform aux = mouseItem.transform.parent;
                mouseItem.transform.SetParent(button.transform.parent);
                button.transform.SetParent(aux);
            }
        }
    }

    /*public void caindo(Rigidbody2D rig)
    {
        StartCoroutine(CaindoCouroutine(rig));
    } 


    IEnumerator CaindoCouroutine(Rigidbody2D rig)
    {
        yield return new WaitForSeconds(0.5f);
        rig.bodyType = RigidbodyType2D.Kinematic;
    }*/
}
