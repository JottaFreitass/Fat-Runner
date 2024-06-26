using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Inventory : MonoBehaviour
{
    public GameObject mouseItem;
    public Item[] item;
    public Camera mainCamera;
 

    public void DragItem(GameObject button)
    {
        Image imageComponent = button.GetComponent<Image>();
        if (imageComponent != null && imageComponent.color.a > 0f)
        {
            mouseItem = button;
            mouseItem.transform.position = Input.mousePosition;
        }
    }
 
    public void DropItem(GameObject button)
    {
        if (mouseItem != null)
        {
            
            Image imageComponent = mouseItem.GetComponent<Image>();
            if (button.name.Equals("Drop"))
            { 
                int pos = int.Parse(mouseItem.name);
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 10.0f;
                Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
                Instantiate(item[pos].prefab, worldPosition, Quaternion.identity);
                desaparecer();
            }
            else
            {
                Transform aux = mouseItem.transform.parent;
                mouseItem.transform.SetParent(button.transform.parent);
                button.transform.SetParent(aux); 
                
                Image mouseItemImage = mouseItem.GetComponent<Image>();

                if (mouseItemImage != null)
                {
                    Color newColor = mouseItemImage.color;
                    newColor.a = 1f;
                    mouseItemImage.color = newColor;
                }
            }
            mouseItem = null;
        }
    }

    public void desaparecer()
    {
        Image imageComponent = mouseItem.GetComponent<Image>();

        if (imageComponent != null)
        {
            Color newColor = imageComponent.color;
            newColor.a = 0f;
            imageComponent.color = newColor;
        }
    }
    public void aparecer()
    {
        Image imageComponent = mouseItem.GetComponent<Image>();

        if (imageComponent != null)
        {
            Color newColor = imageComponent.color;
            newColor.a = 1f;
            imageComponent.color = newColor;
        }
    }
}
 