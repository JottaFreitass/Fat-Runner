using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Botao : MonoBehaviour
{  
    [SerializeField]
    Andar PlayerScript;
    [SerializeField]
    public GameObject player;
    
    [SerializeField]
    private Button BotaoJogar;

    public bool andar_cima;
    GameObject MenuGameUI;

    private void Awake()
    {
        BotaoJogar.onClick.AddListener(OnButtonPlayClickJogar);
    }

    private void OnButtonPlayClickJogar()
    {
        Debug.Log("JOGAR");
        
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void MovimentoBotaoCima()
    {
        andar_cima = true;
    }

    public void pararMovimento()
    {
        andar_cima = false;
    }
}
