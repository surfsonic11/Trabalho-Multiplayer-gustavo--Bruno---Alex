using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
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
