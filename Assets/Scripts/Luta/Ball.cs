using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Imports")]
    public SpriteRenderer sprt;
    public GameObject ball1;
    private Animator animator;
    

    private int Lado;

    public bool InLUTA;

    void Start()
    {
        animator = GetComponent<Animator>();
        Lado = Random.Range(1, 4);
        
        if (InLUTA)
        {
            SpawnBall();
        }
    }

    void Update()
    {

    }

    public void SpawnBall()
    {
        ball1.SetActive(true);
        if (Lado == 1)   // Lado 1 = Esquerda
        {
            transform.position = new Vector3(-2f, Random.Range(-8, 8), 0f);
            Debug.Log("Esquerda");
        }

        if (Lado == 2)   // Lado 2 = Cima
        {
            transform.position = new Vector3(Random.Range(-2, 2), 8, 0f);
            Debug.Log("Cima");
        }

        if (Lado == 3)   // Lado 3 = Direita
        {
            transform.position = new Vector3(2f, Random.Range(-8, 8), 0f);
            Debug.Log("Direita");
        }

        if (Lado == 4)  // Lado 4 = Baixo
        {
            transform.position = new Vector3(Random.Range(-2, 2), -8, 0f);
            Debug.Log("Baixo");
        }
    }
}
