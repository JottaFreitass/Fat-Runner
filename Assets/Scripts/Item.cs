using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{
    public string id;
    public int iAttack;
    public Sprite sprite;
    public Transform prefab;

    public Rigidbody2D rig;
}
