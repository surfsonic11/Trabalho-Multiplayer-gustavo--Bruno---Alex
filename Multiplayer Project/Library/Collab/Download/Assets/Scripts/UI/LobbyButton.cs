using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyButton : MonoBehaviour
{
    public void EnterGame()
    {
        GameManager.instance.SortNum = Random.Range(0, GameManager.instance.playerQ.Count);
        GameManager.instance.PlayerGM();
        Debug.Log(GameManager.instance.SortNum);
        
        StateMachine.instance.ChangeTo<Gameplay>();       
    }
}
