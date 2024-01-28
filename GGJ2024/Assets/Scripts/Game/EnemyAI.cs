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
    Animator anim;

    //Variables to determine the state of the AI
    public float chaseRange, attackRange;
    public bool playerInChaseRange, playerInAttackRange;

    public AudioSource source;
    public AudioClip clip;

    public bool audioPlayed = false;

    [SerializeField] bool canKillPlayer = false;

    public float timeBetweenAttacks;
    bool hasAttacked;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

    }

    private void Update()
    {
        playerInChaseRange = Physics.CheckSphere(transform.position, chaseRange, playerDetection);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerDetection);


        if (playerInChaseRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
        if (playerInChaseRange && playerInAttackRange)
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
        anim.SetBool("isMoving",true); //fill in for running anim
        if(audioPlayed == false)
        {
            source.PlayOneShot(clip);
            audioPlayed = true;
        }
    }

    private void AttackPlayer()
    {
        if(anim != null)
        //anim.SetTrigger(""); //fill in for the glorious T-pose
        if (canKillPlayer)
        {
            agent.SetDestination(transform.position);

            transform.LookAt(player);
            Animator anim = Enemy.GetComponent<Animator>();
            //anim.SetTrigger("Attack");
            //^ change this to suite the attack anim for the enemy

            if (!hasAttacked)
            {
                //attacking code should be in here
                hasAttacked = true;
                GameManager.PlayerDeath("Oh wow, I guess that enemy did work, sucks to be you :)");
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
    }

    private void ResetAttack()
    {
        hasAttacked = false;
    }
}
