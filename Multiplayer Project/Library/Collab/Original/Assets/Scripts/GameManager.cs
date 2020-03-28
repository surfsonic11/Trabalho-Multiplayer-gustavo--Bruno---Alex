using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;
    public GameObject Final;
    public GameObject[] spawn = new GameObject[3];
    public GameObject[] ItensSpawn = new GameObject[3];
    public GameObject[] Itens = new GameObject[6];

    public List<PlayerMovement> allPlayers;
    public List<Player> playerQ;

    public int minPlayers = 2;
    public int maxPlayers = 4;
    public int PlayersCount = 0;
    public int TestTime = 60;
    public int SortNum;
    public int Item1, Item2, Item3;

    

    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    //Acessa script de movimentação de todos players na lista possibilitando a desativação
    void SetPlayerState (bool state)
    {
        PlayerMovement[] allPlayers = FindObjectsOfType<PlayerMovement>();
        foreach (PlayerMovement p in allPlayers)
        {
            p.enabled = state;
        }
    }

    //Ativa a movimentação dos players
    public void EnablePlayer()
    {
        SetPlayerState(true);
    }

    //Desativa a movimentação dos players
    public void DisablePlayer()
    {
        SetPlayerState(false);
    }


    public void AddPlayer(Player p)
    {
        if (PlayersCount < maxPlayers)
        {
            allPlayers.Add(p.GetComponent<PlayerMovement>());
            p.ID = PlayersCount + 1;
            PlayersCount++;
        }
    }

    public void PlayerGM()
    {
        for (int i = 0; i < playerQ.Count; i++)
        {
            if (SortNum >= playerQ.Count)
            {
                SortNum = 0;
            }

            if (SortNum == i)
            {
                playerQ[i].tag = "GameMaker";
                playerQ[i].isGameMaker = true;
                playerQ[i].GetComponent<PlayerMovement>().enabled = false;
                playerQ[i].GetComponent<GMDrag>().enabled = true;    
            }
            else
            {
                playerQ[i].tag = "Player";
                playerQ[i].isGameMaker = false;
                playerQ[i].GetComponent<GMDrag>().enabled = false;
                playerQ[i].GetComponent<PlayerMovement>().enabled = true;
            }          
        }
    }

    public void ColorPlayer(Color colorP)
    {
        for (int i = 0; i < playerQ.Count; i++)
        {
            switch (i)
            {
                case 0:
                    playerQ[0].PColor.material.color = Color.green;
                    break;
                case 1:
                    playerQ[1].PColor.material.color = Color.yellow;
                    break;
                case 2:
                    playerQ[2].PColor.material.color = Color.cyan;
                    break;
                case 3:
                    playerQ[3].PColor.material.color = Color.red;
                    break;
                
            }
        }        
    }
}
