using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject Enemy;
    public UnityEngine.AI.NavMeshAgent agent;
    public Transform player;
    public LayerMask groundDetection, playerDetection;
    public GameObject pivot;

    //Variables to determine the state of the AI
    public float chaseRange, attackRange;
    public bool playerInChaseRange, playerInAttackRange;


    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    private void Update()
    {
        playerInChaseRange = Physics.CheckSphere(transform.position, chaseRange, playerDetection);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerDetection);


        if (playerInChaseRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        else if (playerInChaseRange && playerInAttackRange)
        {
            AttackPlayer();
        }
        //prevents rotation on collision
        pivot.transform.LookAt(player);
        gameObject.transform.rotation = new Quaternion(0f, pivot.transform.rotation.y, 0f, pivot.transform.rotation.w);
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        Animator anim = Enemy.GetComponent<Animator>();
        anim.SetTrigger(""); //fill in for running anim
    }

    private void AttackPlayer()
    {
        Animator anim = Enemy.GetComponent<Animator>();
        anim.SetTrigger(""); //fill in for the glorious T-pose
    }
}
