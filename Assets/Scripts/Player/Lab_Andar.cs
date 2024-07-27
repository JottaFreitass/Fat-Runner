using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lab_Andar : MonoBehaviour
{
    [Header("Atributos")]
    public float velocidade;
    public bool Iniciou;
    public float movimentoHorizontal;
    public float movimentoVertical;

    [Header("Imports")]
    public SpriteRenderer SR;
    public Animator animator;
    public Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        StartCoroutine(Comeco());
        Iniciou = false;
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    void Update()
    {
        if (Iniciou)
        {
            Movimento();
        }
    }

    void Movimento()
    {
        movimentoHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * velocidade * movimentoHorizontal);

        movimentoVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * velocidade * movimentoVertical);

        if (Input.GetAxis("Horizontal") < 0)
        {
            SR.flipX = true;
            animator.SetBool("Idle", false);
            animator.SetBool("Lados", true);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
           SR.flipX = false;
            animator.SetBool("Lados", true);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            animator.SetBool("Lados", false);
        }

        if (movimentoVertical < 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            animator.SetBool("Baixo", true);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            animator.SetBool("Baixo", false);
        }
        if (movimentoVertical > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            animator.SetBool("Cima", true);
            animator.SetBool("Idle", false);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            animator.SetBool("Cima", false);
            animator.SetBool("Idle", true);
        }
    }

    IEnumerator Comeco()
    {
        yield return new WaitForSeconds(2);
        Iniciou = true;
        Debug.Log("Começou Lab");
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.CompareTag("TROCA"))
        {
            SceneManager.LoadScene("Jogo");
        }
    }
}