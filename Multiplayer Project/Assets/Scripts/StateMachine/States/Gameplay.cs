using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Gameplay : State
{

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Gemaplys começou");
        //TeleportWait();
        SortItens();
        
    }

    void TeleportWait()
    {
        for (int i = 0; i < Manager.playerQ.Count; i++)
        {
            if (Manager.playerQ[i].tag == "Player")
            {
                Manager.playerQ[i].transform.position = Manager.spawn[1].transform.position;
            }
            else if(Manager.playerQ[i].tag == "GameMaker")
            {
                Manager.playerQ[i].transform.position = Manager.spawn[0].transform.position;
            }

            
        }
    }

     public void Win()
     {
        Debug.Log("AYAYAYAYAY");
        Manager.SortNum++;
        Manager.PlayerGM();
        TrocaGM();
     }

    
    void SortItens()
    {
        Manager.Item1 = Random.Range(0, 6);
        Manager.Item2 = Random.Range(0, 6);
        Manager.Item3 = Random.Range(0, 6);
    }

    
     
    

    public void TestGamePlay()
    {
        for (int i = 0; i < Manager.playerQ.Count; i++)
        {
            if (Manager.playerQ[i].tag == "GameMaker")
            {
                Manager.playerQ[i].transform.position = Manager.spawn[2].transform.position;
                Manager.playerQ[i].gameObject.SetActive(true);
                Manager.playerQ[i].GetComponent<PlayerMovement>().enabled = true;
                Manager.playerQ[i].GetComponent<GMDrag>().enabled = false;
            }
            
        }       
    }

    public void StopTest()
    {
        for (int i = 0; i < Manager.playerQ.Count; i++)
        {
            if (Manager.playerQ[i].tag == "GameMaker")
            {
                Manager.playerQ[i].transform.position = Manager.spawn[0].transform.position;
                Manager.playerQ[i].GetComponent<GMDrag>().enabled = true;
            }
        }       
    }

    public void Gemaplys()
    {
        for (int i = 0; i < Manager.playerQ.Count; i++)
        {
            if (Manager.playerQ[i].tag == "GameMaker")
            {
                Manager.playerQ[i].transform.position = Manager.spawn[0].transform.position;
            }
            else if (Manager.playerQ[i].tag == "Player")
            {
                Manager.playerQ[i].transform.position = Manager.spawn[2].transform.position;
                if(Manager.playerQ[i].Score >= 1)
                {
                    Win();
                }
            }
        }        
    }

    void TrocaGM()
    {
        TeleportWait();
        SortItens();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
