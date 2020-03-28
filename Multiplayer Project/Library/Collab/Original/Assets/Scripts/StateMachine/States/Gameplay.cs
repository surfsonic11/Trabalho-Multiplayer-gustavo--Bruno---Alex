using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : State
{

    public override void Enter()
    {
        base.Enter();
        TeleportWait();
        SortItens();
        GameMakerOn();
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

    void GameMakerOn()
    {
        for (int i = 0; i < Manager.Itens.Length; i++)
        {
            if (Manager.Item1 == i)
            {
                Instantiate(Manager.Itens[i], Manager.ItensSpawn[0].transform.position, transform.rotation);
            }
            else if (Manager.Item2 == i)
            {
                Instantiate(Manager.Itens[i], Manager.ItensSpawn[1].transform.position, transform.rotation);
            }
            else if (Manager.Item3 == i)
            {
                Instantiate(Manager.Itens[i], Manager.ItensSpawn[2].transform.position, transform.rotation);
            }
        }
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
        UIM.TestGamePlay.gameObject.SetActive(false);
        UIM.StopTest.gameObject.SetActive(true);
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

        UIM.StopTest.gameObject.SetActive(false);
        UIM.TestGamePlay.gameObject.SetActive(true);
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
        UIM.TestGamePlay.gameObject.SetActive(false);
        UIM.PlayGamePlay.gameObject.SetActive(false);
    }

    void TrocaGM()
    {
        TeleportWait();
        SortItens();
        GameMakerOn();
        UIM.TestGamePlay.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
