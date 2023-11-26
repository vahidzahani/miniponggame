using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float minVel;
    [SerializeField] private float foreceVel;
    [SerializeField] private GameManager gameManager;
    


    private void Awake(){
        rb=GetComponent<Rigidbody2D>();
    }
    public void Startthegame()
    {
        int rand=Random.Range(0,2);
        if (rand==0)
        {
            rb.AddForce(new Vector2(-direction.x,-direction.y));
        }
        else if(rand==1){
            rb.AddForce(new Vector2(direction.x,direction.y));
        }
    }
    private void Update()
    {
        float xVel=rb.velocity.x;
        if (xVel<minVel && xVel>-minVel && xVel !=0)
        {
            if(xVel>0)
            {
                xVel=foreceVel;
            }else{
                xVel=-foreceVel;
            }
            rb.velocity=new Vector2(xVel,rb.velocity.y);
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "rocket")
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2 + collision.gameObject.GetComponent<Rigidbody2D>().velocity.y / 3);
            gameManager.touchsound();
        }
        if (collision.gameObject.tag == "walls")
        {
            gameManager.touchsound();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag=="endpoint")
        {
            rb.velocity=Vector2.zero;
            transform.position=Vector2.zero;
            if (collision.gameObject.name == "Left")
            {
                gameManager.fn_winner(1);
                print("left");
            }
            if (collision.gameObject.name == "Right") {
                gameManager.fn_winner(0);
                print("rihgt");
            }
        }
    }


    
}
