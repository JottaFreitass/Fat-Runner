using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Veio : MonoBehaviour
{
    public Transform posA, posB , posC, posD;
     public int speed = 2;
    Vector2 posPlat;
    private string chegou;
    
    [SerializeField]
    public Animator anim;
    //public SpriteRenderer SR;


    // Start is called before the first frame update
    void Start()
    {
        posPlat = posA.position;
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Vector2.Distance(transform.position, posA.position) < 0.1f)
        {
            //De A pra B
            anim.SetBool("movimento", true);
            posPlat = posB.position;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);

        } 
        if (Vector2.Distance(transform.position, posB.position) < 0.1f)
        {
            //De B pra C
            posPlat = posC.position;
            anim.SetBool("cima", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);


        }
        if (Vector2.Distance(transform.position, posC.position) < 0.1f)
        {
            posPlat = posD.position;
            anim.SetBool("cima",false);
            anim.SetBool("movimento", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);

            //De C pra D

        }
      
        
        
        transform.position = Vector2.MoveTowards(transform.position, posPlat, speed * Time.deltaTime);
       
      

       
        

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.tag == "Player")
        {
            speed = speed - 2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.tag == "Player")
        {
            speed = 2;
        }
    }
}