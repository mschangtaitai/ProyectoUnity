﻿using System.Collections;
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
        Destroy(gameObject);   
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
