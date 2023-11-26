using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovment : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private KeyCode upvolume;
    [SerializeField] private KeyCode downVolume;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate(){
        if(Input.GetKey(upvolume))
        {
            rb.velocity=new Vector2(0,speed*Time.fixedDeltaTime);
        }else if(Input.GetKey(downVolume)){
            rb.velocity=new Vector2(0,speed*Time.fixedDeltaTime*-1);
        }else
        {
            rb.velocity=Vector2.zero;
        }
    }
}
