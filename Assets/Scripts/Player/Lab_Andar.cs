using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lab_Andar : MonoBehaviour
{

    [Header("Atributs")]
    public int speed = 3;
    public float movimentoHorizontal;
    public float movimentoVertical;
    public int velocidade;
    public bool Iniciou = false;


    [Header("Imports")]
    public SpriteRenderer vira;
    public SpriteRenderer SR;
    public Animator animator;
    public Rigidbody2D rig;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Comecou Lab");
        rig = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        StartCoroutine(Comeco());
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
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


        if (Input.GetAxis("Horizontal") && Input.GetAxis("Vertical") = 0)
        {
            animator.SetBool("Idle", true);

        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            animator.SetBool("Idle", false);
            animator.SetBool("Lados", true);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            animator.SetBool("Lados", true);
        }

        else if (movimentoVertical < 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            animator.SetBool("Baixo", true);
        }
        else if (movimentoVertical > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            animator.SetBool("Cima", true);
            animator.SetBool("Idle", false);
        }

    }

    IEnumerator Comeco()
    {
        yield return new WaitForSeconds(2);
        Iniciou = true;
    }

     void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.CompareTag("TROCA"))
        {
            SceneManager.LoadScene("Jogo");
        }
    }
}