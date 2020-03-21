using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class State : NetworkBehaviour
{
    protected GameManager Manager { get { return GameManager.instance; } }
    protected UIManager UIM { get { return UIManager.instance; } }
    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }
}
