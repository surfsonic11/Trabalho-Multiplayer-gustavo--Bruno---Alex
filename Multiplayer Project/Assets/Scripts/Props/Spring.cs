using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public bool onTop;

    public Animator anim;

    public GameObject bouncer;

    //public SpriteRenderer sRender;

    

    public Vector2 velocity;
    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (onTop)
        {
            anim.SetBool("isStepped", true);
            bouncer = collision.gameObject;
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            onTop = true;
        
            
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        onTop = true;


    }



    private void OnTriggerExit2D(Collider2D other)
    {
        
            onTop = false;
            anim.SetBool("isStepped", false);
        bouncer = null;

    }

    private void Jump()
    {
        bouncer.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    //public void FlipX(bool flipx)
    //{
    //    if (flipx == false)
    //    {
    //        sRender.flipX = false;
    //        velocity.x = velocity.x * -1;
    //    }
    //    else
    //    {
    //        sRender.flipX = true;
    //        velocity.x = velocity.x * -1;
    //    }
    //}
}
