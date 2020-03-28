using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Animator animD;
    public bool isDead;
    public PlayerMovement player;

    private void Start()
    {
        animD = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Spike"))
        {
            if(isDead == false)
            {
                isDead = true;
                player.enabled = false;
                animD.SetTrigger("Death");
            }
            
        }
        
    }

    public void DestroyPlayer()
    {
        if (gameObject.tag == "GameMaker")
        {
            
            isDead = false;
        }
        gameObject.SetActive(false);

    }

    
}
