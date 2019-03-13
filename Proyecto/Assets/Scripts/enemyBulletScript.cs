using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletScript : MonoBehaviour
{
    private float remainTime;

    void Start()
    {
        Destroy(gameObject, 155.0f * Time.deltaTime);

    }


    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<Player>().life -= 20;
            }
        }
    }

}
