using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Dialogo", menuName = "Dialogo")]
public class Dialogo : ScriptableObject
{
    [Header("Construcao Dialogo")]
    public string[] dialogos;
    public string[] quemFala;
    public int[] qualExpressao;
}
