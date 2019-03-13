using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text lifeUI;
    public Camera Camera;
    private GameObject audioManagerObject;
    private AudioManager audioManager;
    private AudioSource audioSource;
    private playerAnimation PlayerAnimation;

    private void Start()
    {
        audioManagerObject = GameObject.Find("Main Camera");
        audioManager = audioManagerObject.GetComponent<AudioManager>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            audioSource.PlayOneShot(audioManager.playerShot, 2f);
            if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out RaycastHit hit, 20.0f) && hit.transform.CompareTag("Enemy"))
            {
                PlayerAnimation = hit.transform.gameObject.GetComponent<playerAnimation>();
                PlayerAnimation.health -= 50;
                //Destroy(hit.transform.gameObject);

            }
        }
    }
}
