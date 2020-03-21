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
        GameManager.instance.ColorPlayer();
        UIManager.instance.StartGame.gameObject.SetActive(false);
        UIManager.instance.LobbyImg.gameObject.SetActive(false);
        StateMachine.instance.ChangeTo<Gameplay>();
        UIManager.instance.TestGamePlay.gameObject.SetActive(true);
    }
}
