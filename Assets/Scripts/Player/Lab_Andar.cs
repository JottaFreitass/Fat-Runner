using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lab_Andar : MonoBehaviour
{
    Rigidbody2D rig;
    public float speed = 3;
    [SerializeField] private Animator animator;
    public float movimentoHorizontal;
    public float movimentoVertical;
    public float velocidade = 10.0f ;
    public bool podeAndar;
    [SerializeField]
    public SpriteRenderer vira;
    SpriteRenderer SR;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Comecou o jogo");
        rig = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        velocidade = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
    }

    void Movimento()
    {
        movimentoHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * velocidade * movimentoHorizontal);
            
        movimentoVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * velocidade * movimentoVertical);

        if (Input.GetAxis("Horizontal") < 0)
        {
            vira.flipX = true;
            animator.SetBool("Idle", false);
            animator.SetBool("Lados", true);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            vira.flipX = false;
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

     void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.CompareTag("TROCA"))
        {
            SceneManager.LoadScene("Jogo");
        }
    }
}