using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask wasIsGround, whatIsPlayer;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States 
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private bool inLight;

    private Animator rubyAnimator;

    private void Start()
    {
        rubyAnimator = GetComponent<Animator>();

    }
    private void Update()
    {
        //check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange && !playerInSightRange) Freeze();
        if (playerInAttackRange && playerInSightRange && !inLight) AttackPlayer();
        if(!playerInAttackRange && playerInSightRange && !inLight) ChasePlayer();
        
    }
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        inLight = false;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        rubyAnimator.SetBool("isRunning", true);
        rubyAnimator.SetBool("isIdle", false);

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("freezelight"))
        {
            inLight = true;
            Freeze();
        }
        if (other.gameObject.CompareTag("lightoff"))
        {
            inLight = false;
        }
    }

    

    private void Freeze()
    {
        rubyAnimator.SetBool("isRunning", false);
        rubyAnimator.SetBool("isIdle", true);
        rubyAnimator.SetBool("isAttacking", false);
        agent.SetDestination(transform.position);
    }
   

    private void AttackPlayer()
    {
        rubyAnimator.SetBool("isAttacking", true);
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        
        if (alreadyAttacked ==false)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        rubyAnimator.SetBool("isAttacking", false);
    }
    
}
