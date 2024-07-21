using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LutaController : MonoBehaviour
{
    public Button Lutar;
    public Button Fugir;
    public string str;
    public Cerebro cerebro; // Use a classe Cerebro
    public Ball bal;

    void Start()
    {
        cerebro = FindObjectOfType<Cerebro>(); // Encontrar a instância de Cerebro
        if (cerebro == null)
        {
            Debug.LogError("Cerebro não encontrado! Verifique se o script Cerebro está anexado a um GameObject.");
        }

        bal = FindObjectOfType<Ball>(); // Encontrar a instância de Ball
        if (bal == null)
        {
            Debug.LogError("Ball não encontrado! Verifique se o script Ball está anexado a um GameObject.");
        }

        Lutar.onClick.AddListener(OnLutarClicked);
        Fugir.onClick.AddListener(OnFugirClicked);
    }

    void OnLutarClicked()
    {
        if (cerebro != null)
        {
            cerebro.isLuta = true;
            Debug.Log("Luta iniciada");
        }
        if (bal != null)
        {
            bal.InLUTA = true;
            Debug.Log("Ball nasceu");
        }
    }

    void OnFugirClicked()
    {
        SceneManager.LoadScene(str);
        Debug.Log("Fugiu para a cena: " + str);
    }
}