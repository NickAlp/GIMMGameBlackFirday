using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    public GameObject player;
    public EnemyState currentState;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public LayerMask whatIsPlayer;
    public EnemyAi ea;
    public float health;
    public float healthRegen;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        ea = GetComponent<EnemyAi>();
        SetState(new EnemyPatrol(this));
    }

    // Update is called once per frame
    void Update()
    {
        currentState.CheckTransitions();
        currentState.Act();
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
    }

    public void SetState(EnemyState es)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = es;

        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }
    
    public void EnemyPatrolState()
    {
        ea.Patroling();
    }
    public void EnemyChaseState()
    {
        ea.ChasePlayer();
    }
    public void EnemyAttackState()
    {
        ea.AttackPlayer();
    }
    public void EnemyFleeState()
    {
        ea.FleePlayer();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Door")
        {
            if (other.GetComponent<AutomaticDoor>().Moving == false)
            {
                other.GetComponent<AutomaticDoor>().Moving = true;
            }
        }
    }
}

