using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int life = 100;
    public Text lifeText;
    private Transform player;
    private GameObject audioManagerObject;
    private AudioManager audioManager;
    private AudioSource audioSource;
    private bool audioPlayed = false;


    void Start()
    {
    player = GetComponent<Transform>();
    audioManagerObject = GameObject.Find("Main Camera");
    audioManager = audioManagerObject.GetComponent<AudioManager>();
    audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        lifeText.text = life.ToString();
        if (life == 0)
        {

            if (!audioPlayed)
            {
                audioPlayed = true;
                audioSource.PlayOneShot(audioManager.diePlayer, 2f);
            }


            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            if (SceneManager.GetActiveScene().name == "Pallet Town")
            {
                SceneManager.LoadScene("Platforms");

            }else if (SceneManager.GetActiveScene().name == "Platforms")
            {
                SceneManager.LoadScene("Parking Tower");
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
