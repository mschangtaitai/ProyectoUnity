using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerAnimation : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;
    public int health = 100;
    private bool alive = true, playedDeath = false, chasePlayer = false;
    private float inputH, inputV;
    public float time;
    public NavMeshAgent agent;
    public Transform[] patrolPoints;
    private int currentPointIndex = 0;
    private GameObject player, bullet=null;
    public GameObject bulletModel;
    private GameObject audioManagerObject;
    private AudioManager audioManager;
    private AudioSource audioSource;


    void Start()
    {
        time = Time.deltaTime;
        player = GameObject.FindWithTag("Player");
        audioManagerObject = GameObject.Find("Main Camera");
        audioManager = audioManagerObject.GetComponent<AudioManager>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (health == 0 && playedDeath == false)
        {
            animator.Play("dieBack", -1);
            alive = false;
            playedDeath = true;
            agent.SetDestination(agent.transform.position);
        }
        if (alive)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 11.0f && !audioSource.isPlaying && (transform.position.y-player.transform.position.y) < 0.3f)
            {
                audioSource.PlayOneShot(audioManager.footStepsEnemy, 1f);
            }
            Animations(agent.velocity);
            shoot();
            moveToPlayer();
            if (agent.remainingDistance < 0.25f)
            {
                moveToNextPatrol();
               

            }

        }


    }
    void Animations(Vector3 velocity)
    {
        if (health == 0 || Input.GetKey("2"))
        {
            alive = false;
            animator.Play("dieBack", -1);
        }
            inputH = velocity.x;
            inputV = velocity.y;
            animator.SetFloat("inputH", inputH);
            animator.SetFloat("inputV", inputV);
    }

    void moveToNextPatrol()
    {

            if (patrolPoints.Length > 0 && Vector3.Distance(transform.position, player.transform.position) >= 25.0f)
            {
                agent.SetDestination(patrolPoints[currentPointIndex].position);
                currentPointIndex++;
                currentPointIndex %= patrolPoints.Length;
            }

    }

    void moveToPlayer()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 25.0f)
            {
                agent.SetDestination(player.transform.position);
            chasePlayer = true;
            
            }
        else if (chasePlayer == true)
        {
            chasePlayer = false;
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }
    }

    void shoot()
    {
        if (Vector3.Distance(transform.position, player.transform.position)< 25.0f && bullet == null && (transform.position.y - player.transform.position.y) < 0.6f)
        {
            Vector3 holder = transform.position;
            holder.y += 1f;
            bullet = Instantiate(bulletModel, holder, transform.rotation);
            Vector3 directionVector = player.transform.position - agent.transform.position;
            directionVector.y -= 1f;
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = directionVector * 2.5f;
            audioSource.PlayOneShot(audioManager.shot, 1f);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "playerBullet")
        {  
            health -= 50;
            animator.Play("dieBack", -1);
        }
    }
}