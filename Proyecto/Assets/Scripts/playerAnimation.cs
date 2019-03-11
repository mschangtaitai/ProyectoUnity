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
    private bool shooting = false;
    private GameObject audioManagerObject;
    private AudioManager audioManager;
    private AudioSource audioSource;
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
        audioManagerObject = GameObject.Find("Main Camera");
        audioManager = audioManagerObject.GetComponent<AudioManager>();
        audioSource = GetComponent<AudioSource>();
        //rifle = GameObject.Find("Weapon");
        //agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 11.0f && !audioSource.isPlaying && (transform.position.y-player.transform.position.y) < 0.3f)
            {
                audioSource.PlayOneShot(audioManager.footStepsEnemy, 1f);
            }
            Animations(agent.velocity);
            shoot();
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

            if (patrolPoints.Length > 0)
            {
                agent.SetDestination(patrolPoints[currentPointIndex].position);
                currentPointIndex++;
                currentPointIndex %= patrolPoints.Length;
            }

    }
    void shoot()
    {
        if (Vector3.Distance(transform.position, player.transform.position)< 25.0f && bullet == null && !audioSource.isPlaying && (transform.position.y - player.transform.position.y) < 0.6f)
        {
            shooting = true;
            //animator.Play("shoot", -1);
            Vector3 holder = transform.position;
            holder.y += 1f;
            bullet = Instantiate(bulletModel, holder, transform.rotation);
            Vector3 directionVector = player.transform.position - agent.transform.position;
            directionVector.y -= 1f;
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = directionVector * 0.5f;
            Debug.Log("a");
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