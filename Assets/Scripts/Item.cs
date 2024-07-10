using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{
    public string id;
    public int iAttack;
    public Transform prefab;
    public Sprite sprite;
    public Rigidbody2D rig;
    public GameObject itemImage;
}
