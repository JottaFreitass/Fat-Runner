using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Andar : MonoBehaviour
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
    public GameObject inventario;
    private Inventory inventoryScript;
    SpriteRenderer SR;
    
    void Start()
    {
        Debug.Log("Comecou o jogo");
        rig = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        velocidade = 5;
        podeAndar = true;
        inventoryScript = inventario.GetComponent<Inventory>();
    }

    void Update()
    {
        if (podeAndar == true)
        {
            Movimento();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            bool isActive = !inventario.activeSelf;
            inventario.SetActive(isActive);
            podeAndar = !inventario.activeSelf;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("0"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[0].itemImage;    
            inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("1"))
        {
           Destroy(other.gameObject);
           inventario.SetActive(true);
           podeAndar = false;
           inventoryScript.mouseItem = inventoryScript.item[1].itemImage;
           inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("2"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[2].itemImage;
            inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("3"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[3].itemImage;
            inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("4"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[4].itemImage;
            inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("5"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[5].itemImage;
            inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("6"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[6].itemImage;
            inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("7"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[7].itemImage;
            inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("8"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[8].itemImage;
            inventoryScript.aparecer();
        }
        else if (other.gameObject.CompareTag("9"))
        {
            Destroy(other.gameObject);
            inventario.SetActive(true);
            podeAndar = false;
            inventoryScript.mouseItem = inventoryScript.item[9].itemImage;
            inventoryScript.aparecer();
        }
    }
}
