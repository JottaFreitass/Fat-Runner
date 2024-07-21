using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class luta : MonoBehaviour
{
    public GameObject player;
    public string str;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Encontra um único objeto com a tag "Player"
        if (player == null)
        {
            Debug.LogError("Player não encontrado!");
        }
    }

    private void Update()
    {
        if (player != null && Vector2.Distance(player.transform.position, transform.position) < 2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Missão Iniciada!");
                SceneManager.LoadScene(str);
            }
        }
    }
}