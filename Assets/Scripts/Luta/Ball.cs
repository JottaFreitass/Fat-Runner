using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Imports")]
    public SpriteRenderer sprt;
    public GameObject ball1;
    [SerializeField]
    Animator animator;
    private int Lado;
    public bool InLUTA;
    private int TempoMaxLuta = 120;

    private int tempoLuta = 0;
    public bool isChangingAttack = false;

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
        if (InLUTA && tempoLuta < TempoMaxLuta && !isChangingAttack)
        {
            StartCoroutine(MudarAtaque());
        }
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

    IEnumerator MudarAtaque()
    {
        isChangingAttack = true;
        if (InLUTA)
        {  
            animator.SetBool("atk2", true);
            if (tempoLuta >= TempoMaxLuta)
            {
                yield break;
            }
            while (tempoLuta < TempoMaxLuta)
            {
                if (animator.GetBool("atk1"))
                {
                    yield return new WaitForSeconds(9.0f);
                    animator.SetBool("atk1", false);
                    animator.SetBool("atk2", true);
                    tempoLuta += 10;
                } 
                else if (animator.GetBool("atk2"))
                {
                    yield return new WaitForSeconds(7.8f);
                    animator.SetBool("atk2", false);
                    animator.SetBool("atk1", true);
                    tempoLuta += 10;
                }            
            }
        }
        isChangingAttack = false;
    }
}