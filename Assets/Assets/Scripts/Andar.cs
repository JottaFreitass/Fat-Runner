using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Andar : MonoBehaviour
{
    public Rigidbody2D rig;
    public float speed = 3;
    [SerializeField] private Animator animator;
    public float movimentoHorizontal;
    public float movimentoVertical;
    public float velocidade = 0.0f ;
    

    void Start()
    {
        Debug.Log("Comecou o jogo");
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
    }

    void Movimento()
    {
        /*Vector2 MoveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rig.velocity = MoveInput * speed;*/

            movimentoHorizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right*Time.deltaTime*velocidade*movimentoHorizontal);
            
            movimentoVertical = Input.GetAxis("Vertical");
             transform.Translate(Vector3.up*Time.deltaTime*velocidade*movimentoVertical);





        if (movimentoHorizontal < 0)
        {
            animator.SetBool("esquerda", true);
        }
        else
        {
            animator.SetBool("esquerda", false);
        }
        if (movimentoHorizontal > 0)
        {
            animator.SetBool("direita", true);
        }
        else
        {
            animator.SetBool("direita", false);
        }

        if (movimentoVertical < 0)
        {
            animator.SetBool("baixo", true);
        }
        else
        {
            animator.SetBool("baixo", false);
        }
        if (movimentoVertical > 0)
        {
            animator.SetBool("cima", true);
        }
        else
        {
            animator.SetBool("cima", false);
        }

    }

}
