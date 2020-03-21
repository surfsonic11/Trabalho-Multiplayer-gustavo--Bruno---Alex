using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private float h, v;

    [SerializeField]
    private float speed = 2;

    public Rigidbody2D rbPlayer;

    [SerializeField]
    private float jumpForce = 9;

    public bool isGrounded;

    public Animator animator;

    public float rbVelocityY;

    public bool isFacingRight;

    public SpriteRenderer sprite;

    public float baseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    private void Movement()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        rbVelocityY = rbPlayer.velocity.y;
        animator.SetFloat("VelocityY", rbVelocityY);
        Vector3 movement = new Vector3(h, 0, 0);
        transform.position += movement * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rbPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            
        }
        if (isGrounded)
        {
            animator.SetBool("IsGrounded", true);
        }
        else
        {
            animator.SetBool("IsGrounded", false);
        }
       
        if(h < 0)
        {
            sprite.flipX = true;
            isFacingRight = true;
        }
        else if(h > 0)
        {
            isFacingRight = false;
            sprite.flipX = false;
        }
        
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        //if(Mathf.Abs(baseSpeed) > Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x))
        //{
        //    baseSpeed = 0;
        //}
    }

}
