using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class PlayerMovement : NetworkBehaviour
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

    private Material cachedMaterial;

    [SyncVar(hook = "SetColor")] private Color playerColor;

    public Color PlayerColor { set { playerColor = value; } }

    public float baseSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (!isLocalPlayer)
            return;

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

    public void ChangeColor(Color _color)
    {
        playerColor = _color;
    }

    private void SetColor(Color oldColor, Color newColor)
    {
        if (cachedMaterial == null)
        {
            cachedMaterial = sprite.material;
        }

        cachedMaterial.color = newColor;
    }

    private Color RandomColor()
    {
        Color randomColor;

        randomColor = new Color
            (
                Random.Range(.0f, 1f), Random.Range(.0f, 1f), Random.Range(.0f, 1f)
            );

        return randomColor;
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        playerColor = RandomColor();
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        //if(Mathf.Abs(baseSpeed) > Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x))
        //{
        //    baseSpeed = 0;
        //}
    }

}
