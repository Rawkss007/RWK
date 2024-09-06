using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;            
    public int speed = 5;       
    public int jumpForce = 5; 
    private bool hasJumped = false;

    public bool virarDireita = true;
    public bool virarEsquerda = false;
    public GameObject projetil;
    public Transform arminha;
    bool disparei = false;
    public float velocidadeDeDisparo;
    public Animator anima;
    
   void Start() 
   {
     rig=GetComponent<Rigidbody2D>();       
   }
   void Update()
   {
     mover();    
     pular();    
     if(Input.GetButtonDown ("Fire1") && !disparei)
     {
        disparei = true;
        atirar();
     }

   }
   
   
   void mover()
   {
     rig.velocity = new Vector2(Input.GetAxis("Horizontal")  * speed, rig.velocity.y);  // movimentacao do Player
     if((rig.velocity.x > 0 && !virarDireita) || (rig.velocity.x <0 && virarDireita))     
     {
         virar();
     }
     if(rig.velocity.x !=0)
     {
      anima.SetBool("RUN",true);
     }else{
      anima.SetBool("RUN",false);
     }


   }
    void virar()
    {
      virarDireita = !virarDireita;
      Vector3 posicao = transform.localScale;
      posicao.x *= -1;
      transform.localScale = posicao;
    }

   void pular()
  {
     if((Input.GetKeyDown(KeyCode.Space) && !hasJumped))  // movimentacao de pulo do Player  
     {
       rig.velocity=Vector2.up * jumpForce;
       hasJumped = true;
     }
  }
   void atirar()
   {
       if(disparei)
       {
        GameObject tiro = Instantiate(projetil, arminha.position, Quaternion.identity);
        disparei = false;
        if(virarDireita)
        {
          tiro.GetComponent <Rigidbody2D> ().AddForce (Vector2.right * velocidadeDeDisparo);
        }
        else
        {
          tiro.GetComponent <Rigidbody2D> ().AddForce (Vector2.left * velocidadeDeDisparo);
        }

       }

   }

  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Ground"))
    {
        hasJumped = false;
    }
    
  }
  



}
  

