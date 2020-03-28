using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Player : MonoBehaviour
{

    public int ID;
    public int Score;

    public string Name = "Player";

    public Text txt;

    public GMDrag GMDrag;

    public bool isGameMaker;

    public void Start()
    { 

        gameObject.AddComponent<PlayerSpawn>();
        gameObject.AddComponent<PlayerMovement>();
        gameObject.AddComponent<Grounded>();
        txt = GetComponentInChildren<Text>();
        GMDrag = GetComponent<GMDrag>();

        //Chama o void AddPlayer e adiciona um ID e contagem de players para o GameManager
        GameManager.instance.AddPlayer(this);
        //Adiciona o player a Lista de Players
        GameManager.instance.playerQ.Add(this);
        this.gameObject.tag = "Player";
        txt.text = Name + " " + ID;
    }
}

//public static class PlayerWriterReader
//{
//    public static void WriterPlayer(this NetworkWriter writer, Player player)
//    {
//        writer.Write(player);
//    }

//    public static Player ReadPlayer(this NetworkReader reader)
//    {
//        return new Player(reader.ReadPlayer());
//    }
//}
