using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    protected EnemyStateController eSc;

    public abstract void CheckTransitions();

    public abstract void Act();

    public virtual void OnStateEnter() { }

    public virtual void OnStateExit() { }

    public EnemyState(EnemyStateController eSc)
    {
        this.eSc = eSc;
    }
}