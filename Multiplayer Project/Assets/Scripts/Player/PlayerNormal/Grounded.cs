using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public PlayerMovement player;

    private void Start()
    {
        player = gameObject.GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            player.isGrounded = true;
        }

        if (collision.tag == "Platform" && player.isGrounded == false)
        {
            player.isGrounded = true;
            player.transform.parent = collision.gameObject.transform;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            player.isGrounded = true;
        }

        if (collision.tag == "Platform" && player.isGrounded == false)
        {
            player.isGrounded = true;
            player.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            player.isGrounded = false;
        }

        if (other.tag == "Platform")
        {
            player.isGrounded = false;
            player.transform.parent = null;
        }


    }
}
