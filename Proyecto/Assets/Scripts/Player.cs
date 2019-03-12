using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int life = 100;
    public Text lifeText;
    private GameObject audioManagerObject;
private AudioManager audioManager;
    private AudioSource audio;
    private bool audioPlayed = false;

    void Start()
    {
        audioManagerObject = GameObject.Find("Main Camera");
        audioManager = audioManagerObject.GetComponent<AudioManager>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = life.ToString(); 
        if (life == 0)
        {

            if (!audioPlayed)
                audioPlayed = true;
                audio.PlayOneShot(audioManager.diePlayer, 2f);
                


            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
