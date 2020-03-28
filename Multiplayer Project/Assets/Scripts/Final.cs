using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "GameMaker" && other.GetComponent<PlayerDeath>().isDead == false)
        {
            
            for (int i = 0; i < GameManager.instance.playerQ.Count; i++)
            {
                if (GameManager.instance.playerQ[i].tag == "GameMaker")
                {
                    GameManager.instance.playerQ[i].transform.position = GameManager.instance.spawn[0].transform.position;
                    GameManager.instance.playerQ[i].GetComponent<GMDrag>().enabled = true;
                }
            }
            
        }
        else if (other.tag == "Player" && other.GetComponent<PlayerDeath>().isDead == false)
        {
            for (int i = 0; i < GameManager.instance.playerQ.Count; i++)
            {
                if (GameManager.instance.playerQ[i].tag == "Player")
                {
                    StateMachine.instance.current.GetComponent<Gameplay>().Win();
                }
            }
        }
    }
}
