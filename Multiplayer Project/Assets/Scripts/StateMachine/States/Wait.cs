using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : State
{
    public override void Enter()
    {
        base.Enter();
        //StartCoroutine(LobbyEnter());
    }

    //public IEnumerator LobbyEnter()
    //{
    //    while (GameManager.instance.PlayersCount < GameManager.instance.minPlayers)
    //    {
    //        GameManager.instance.DisablePlayer();
    //        yield return null;
    //    }        
    //}

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    if (Manager.PlayersCount < Manager.maxPlayers)
        //    {
        //        Instantiate(Manager.player, Manager.spawn[0].transform.position, transform.rotation);
        //    }
        //}

        if (Manager.PlayersCount >= Manager.minPlayers)
        {
            UIM.StartGame.gameObject.SetActive(true);
            if (StateMachine.instance.current != this)
            {
                UIM.StartGame.gameObject.SetActive(false);
            }
        }
    }    

    public override void Exit()
    {
        base.Exit();
    }
}
