using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cerebro : MonoBehaviour
{
    private Vector3 Startingpos = Vector3.zero;
    private Vector2 MovePos;

    [Header("Atributos")]
    public int life;
    public float speed;
    public float Sensitivity;
    public bool isLuta, noLuta;

    private int MaxX = 2;
    private int MaxY = 2;
    private int MinX = -2;
    private int MinY = -2;

    [Header("Imports")]
    public GameObject InLUTA;
    public GameObject OutLUTA;
    public GameObject Player;
    public GameObject LifeCanvas;

    public Ball bal;
    
    void Start()
    {
        isLuta = false;
        InLUTA.SetActive(false);
        OutLUTA.SetActive(true);
        SetBrain();

        bal = FindObjectOfType<Ball>(); // Encontrar a instância de Ball
        if (bal == null)
        {
            Debug.LogError("Ball não encontrado! Verifique se o script Ball está anexado a um GameObject.");
        }
    }

    public void SetBrain()
    {
        transform.position = Startingpos;
        MovePos = Startingpos;
    }

    private void FixedUpdate()
    {
        if (isLuta)
        {
            Movimento();
            Luta();
            Vida();
            bal.InLUTA = true;
        }
        else if (noLuta)
        {
            InLUTA.SetActive(false);
            OutLUTA.SetActive(true);
            bal.InLUTA = false;
        }
    }

    public void Movimento()
    {
        Player.SetActive(true);
        float horizontal = Input.GetAxis("Horizontal") * Sensitivity;
        float vertical = Input.GetAxis("Vertical") * Sensitivity;

        MovePos.x += horizontal;
        MovePos.y += vertical;

        MovePos.x = Mathf.Clamp(MovePos.x, MinX, MaxX);
        MovePos.y = Mathf.Clamp(MovePos.y, MinY, MaxY);

        transform.position = Vector2.Lerp(transform.position, MovePos, speed * Time.deltaTime);
    }

    public void Luta()
    {
        InLUTA.SetActive(true);
        OutLUTA.SetActive(false);
    }

    public void Vida()
    {
        if (life <= 0)
        {
            SceneManager.LoadScene("Jogo");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Verifique se o objeto com o qual colidiu tem a tag "Ball"
        if (col.CompareTag("Ball"))
        {
            life -= 1; // Reduza a vida pelo valor de dano
            Debug.Log("Colidiu com a Ball! Vida restante: " + life);
        }
    }
}
