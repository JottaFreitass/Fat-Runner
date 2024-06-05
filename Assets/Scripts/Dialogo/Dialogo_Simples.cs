 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo_Simples1 : MonoBehaviour
{
    [SerializeField] Dialogo[] TodosDialogos;

    [Header("Outras Coisas")]
    [SerializeField] Text interagir;
    [SerializeField] int h, v;

    [SerializeField] DialogoController dialogo;
    private bool emDialogo;

    [SerializeField] int qualFala;

    [SerializeField] GameObject Player;
    public GameObject Balao_Velho;
    public GameObject Balao_Velho2;

    public GameObject Painel;

    private void Awake()
    {
        qualFala = 0;
        Player = GameObject.FindWithTag("Player");
        Balao_Velho = GameObject.FindWithTag("BALAO");
        Balao_Velho2 = GameObject.FindWithTag("BALAO2");
        Painel = GameObject.Find("Painel");
    }

    private void Start()
    {
        Balao_Velho2.SetActive(false);
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && emDialogo == true)
        {
            StartCoroutine(Andar());
            Player.GetComponent<Andar>().podeAndar = false;
            if (dialogo.aindaFalando == false)
            {
                dialogo.Dialogo(TodosDialogos[qualFala].dialogos);
                dialogo.MudarExpressao(TodosDialogos[qualFala].quemFala, TodosDialogos[qualFala].qualExpressao);
            }
            //interagir.gameObject.SetActive(false);

            if (!(dialogo.indexFala < TodosDialogos[qualFala].dialogos.Length - 1))
            {
                emDialogo = false;
                qualFala += 1;
                Player.GetComponent<Andar>().podeAndar = true;
            }

            /*if (distance.x < -0.7)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }*/

        }
        if (qualFala > (TodosDialogos.Length - 1))
        {
            qualFala = TodosDialogos.Length - 1;
        }
        if(dialogo.aindaFalando == true)
        {
            Balao_Velho2.SetActive(true);
            Balao_Velho.SetActive(false);
        }
        else if (dialogo.aindaFalando == false)
        {
            Balao_Velho.SetActive(true);
            Balao_Velho2.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log(qualFala);
            emDialogo = true;
            dialogo.indexFala = 0;
            //interagir.gameObject.SetActive(true);
            StopAllCoroutines();
        }

       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            //interagir.gameObject.SetActive(false);
            emDialogo = false;
            dialogo.EncerrarDialogo();
            StartCoroutine(PararDialogo());


        }
    }

    IEnumerator PararDialogo()
    {
        yield return new WaitForSeconds(3f);
        if (h == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    IEnumerator Andar()
    {
        yield return new WaitForSeconds(1.5f);
        Player.GetComponent<Andar>().podeAndar = true;
    }
}