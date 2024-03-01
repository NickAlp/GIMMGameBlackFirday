using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyState
{
    public EnemyChase(EnemyStateController eSc) : base(eSc) { }

    public override void OnStateEnter()
    {
        Debug.Log("Chasing");
    }

    public override void CheckTransitions()
    {
        if (eSc.playerInSightRange && eSc.playerInAttackRange)
        {
            eSc.SetState(new EnemyAttack(eSc));
        }
        if (eSc.ea.health <= 30)
        {
            eSc.SetState(new EnemyFlee(eSc));
        }
    }

    public override void Act()
    {
        eSc.EnemyChaseState();
    }

    public override void OnStateExit() { }
}
