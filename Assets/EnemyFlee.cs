using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlee : EnemyState
{
    public EnemyFlee(EnemyStateController eSc) : base(eSc) { }

    public override void OnStateEnter()
    {
        Debug.Log("Fleeing");
    }

    public override void CheckTransitions()
    {
        if (!eSc.playerInSightRange)
        {
            eSc.SetState(new EnemyPatrol(eSc));
        }
    }

    public override void Act()
    {
        eSc.EnemyFleeState();
    }

    public override void OnStateExit() { }
}
