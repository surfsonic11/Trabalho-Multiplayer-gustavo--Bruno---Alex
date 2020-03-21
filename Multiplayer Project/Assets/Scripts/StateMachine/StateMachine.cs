using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public static StateMachine instance;

    State _current;

    bool busy;

    public State current { get { return _current; } }

    private void Awake()
    {
        if(instance != this && instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        ChangeTo<Wait>();
    }

    public void ChangeTo<T>() where T : State
    {
        State state = GetState<T>();
        if(_current != state)
        {
            ChangeState(state);
        }
    }

    public T GetState<T>() where T : State
    {
        T target = GetComponent<T>();
        if (target == null)
        {
            target = gameObject.AddComponent<T>();
        }
        return target;
    }

    protected void ChangeState(State value)
    {
        if (busy)
        {
            return;
        }
        busy = true;

        if(_current = null)
        {
            _current.Exit();
        }

        _current = value;

        if(_current != null)
        {
            _current.Enter();
        }
        busy = false;
    }

}
