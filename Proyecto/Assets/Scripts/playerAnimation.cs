using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerAnimation : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;
    public int health = 100;
    private bool alive = true;
    private float inputH, inputV;
    public float time;
    public NavMeshAgent agent;
    public Transform[] patrolPoints;
    private int currentPointIndex = 0;
    private GameObject player, bullet=null, rifle;
    public GameObject bulletModel;
    
    // Start is called before the first frame update
    private void Awake()
    {
        //moveToNextPatrol();
    }
    void Start()
    {
        //animator = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();
        time = Time.deltaTime;
        player = GameObject.FindWithTag("Player");
        rifle = GameObject.Find("Weapon");
        //agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            Animations(agent.velocity);
            shoot();
            Debug.Log(player);
            if (agent.remainingDistance < 0.25f)
            {
                //Debug.Log("a");
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

            if (patrolPoints.Length > 0)
            {
                agent.SetDestination(patrolPoints[currentPointIndex].position);
                currentPointIndex++;
                currentPointIndex %= patrolPoints.Length;
            }

    }
    void shoot()
    {
        Debug.Log(Vector3.Distance(transform.position, player.transform.position) < 25.0f);
        if (Vector3.Distance(transform.position, player.transform.position)< 25.0f && bullet == null)
        {
            //notShooting = false;
            bullet = Instantiate(bulletModel, rifle.transform.position, transform.rotation);
            Vector3 directionVector = player.transform.position - agent.transform.position;
            directionVector.y -= 1f;
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = directionVector * 0.5f;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "playerBullet")
        {  
            health -= 50;
        }
    }
}