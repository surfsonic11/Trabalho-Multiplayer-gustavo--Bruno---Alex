using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Player : NetworkBehaviour
{

    public int ID;
    public int Score;

    public string Name = "Player";

    public Text txt;

    public SpriteRenderer PColor;

    public GMDrag GMDrag;

    public bool isGameMaker;
    private Player player;

    //public Player(Player player)
    //{
    //    this.player = player;
    //}

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        
        PColor = GetComponent<SpriteRenderer>();
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
//    public static void WriterPlayer (this NetworkWriter writer, Player player)
//    {
//        writer.Write(player);
//    }

//    public static Player ReadPlayer(this NetworkReader reader)
//    {
//        return new Player(reader.ReadPlayer());
//    }
//}
