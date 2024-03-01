using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPatrol : EnemyState
{
    public EnemyPatrol(EnemyStateController eSc) : base(eSc) { }
    
    public override void OnStateEnter()
    {
        Debug.Log("Patroling");
    }

    public override void CheckTransitions()
    {
        if (eSc.playerInSightRange && !eSc.playerInAttackRange)
        {
            eSc.SetState(new EnemyChase(eSc));
        }
    }

    public override void Act() 
    {
        if (eSc.health < eSc.maxHealth)
        {
            eSc.health += eSc.healthRegen * Time.deltaTime;
        }
    }

    public override void OnStateExit() { }
}
