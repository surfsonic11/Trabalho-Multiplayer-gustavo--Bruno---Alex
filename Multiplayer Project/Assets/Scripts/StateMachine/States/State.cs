using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class State : NetworkBehaviour
{
    protected GameManager Manager { get { return GameManager.instance; } }
    protected UXManager UIM { get { return UXManager.instance; } }

    
    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }
}
