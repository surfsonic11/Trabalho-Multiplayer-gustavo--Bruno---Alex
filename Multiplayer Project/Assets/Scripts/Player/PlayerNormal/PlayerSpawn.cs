using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public PlayerMovement pSpawn;

    private void Awake()
    {
        
        
    }

    private void Start()
    {
        pSpawn = GetComponent<PlayerMovement>();
        disablePlayer();
    }

    void disablePlayer()
    {
        pSpawn.enabled = false;
    }

    void enablePlayer()
    {
        pSpawn.enabled = true;
    }
}
