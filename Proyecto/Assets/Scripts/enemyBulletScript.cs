using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletScript : MonoBehaviour
{
    private float remainTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 155.0f * Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
<<<<<<< HEAD
        Destroy(other.gameObject);
=======
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("a");
            Destroy(gameObject);
        }
>>>>>>> fec9edf8b644c9e71fb5b2c8c69670177a201c85
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("a");
            Destroy(gameObject);
        }
    }
}
