using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyState
{
    public EnemyAttack(EnemyStateController eSc) : base(eSc) { }

    public override void OnStateEnter()
    {
        Debug.Log("Attacking");
    }

    public override void CheckTransitions()
    {
        if (!eSc.playerInAttackRange && !eSc.playerInSightRange)
        {
            eSc.SetState(new EnemyPatrol(eSc));
        }
        if (eSc.ea.health <= 30)
        {
            eSc.SetState(new EnemyFlee(eSc));
        }
    }

    public override void Act()
    {
        eSc.EnemyAttackState();
    }

    public override void OnStateExit() { }
}
