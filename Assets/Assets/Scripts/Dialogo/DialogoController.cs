using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoController : MonoBehaviour
{
    [SerializeField] Image iconPersonagem;

    [SerializeField] Sprite[] PlayerFace;

    [SerializeField] Sprite[] NPCFace;

    [SerializeField] float cdPular;

    [SerializeField] public Text textoDialogo;

    [SerializeField] GameObject painelDialogo;

    private float speedText;

    [SerializeField] float speedBase;

    private string[] dialogoNPC;

    public int indexFala;

    public bool aindaFalando = false;


    private void Awake()
    {
        speedText = speedBase;
    }
    private void Update()
    {
        if (painelDialogo.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ProximoDialogo();
                
            }
        }

    }
    

    public void MudarExpressao(string[] personagem, int[] indexE)
    {
        if (personagem[indexFala] == "")
        {

        }
        if (personagem[indexFala] == "Player")
        {
            iconPersonagem.sprite = PlayerFace[indexE[indexFala]];
        }

        if (personagem[indexFala] == "NPC")
        {
            iconPersonagem.sprite = NPCFace[indexE[indexFala]];
        }

    }

    public void Dialogo(string[] falas)
    {
        
        aindaFalando = true;
        if (painelDialogo.activeSelf == false)
        {
            painelDialogo.SetActive(true);
        }
        
        dialogoNPC = falas;
        StartCoroutine(PassarOTexto());
    }

    public void EncerrarDialogo()
    {
        textoDialogo.text = "";
        indexFala = 0;
        painelDialogo.SetActive(false);
        aindaFalando = false;
        speedText = speedBase;
    }

    IEnumerator PassarOTexto()
    {
        textoDialogo.text = "";
        foreach (char letter in dialogoNPC[indexFala].ToCharArray())
        {
            textoDialogo.text += letter;
            yield return new WaitForSeconds(speedText);
            
        }
    }

    public void ProximoDialogo()
    {
        /*if (textoDialogo.text != dialogoNPC[indexFala])
        {
            StopCoroutine(PassarOTexto());
            textoDialogo.text = dialogoNPC[indexFala];
        }*/

        if (textoDialogo.text == dialogoNPC[indexFala])
        {
            if (indexFala < dialogoNPC.Length - 1)
            {
                speedText = speedBase;
                textoDialogo.text = "";
                indexFala++;
            }
            else
            {
                EncerrarDialogo();
            }

            aindaFalando = false;
        }
        else
        {
            speedText = 0.00001f;
        }  
    }
}
