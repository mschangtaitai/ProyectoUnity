using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathAudio : MonoBehaviour
{
    private GameObject audioManagerObject;
    private AudioManager audioManager;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioManagerObject = GameObject.Find("Main Camera");
        audioManager = audioManagerObject.GetComponent<AudioManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    { 
        audioSource.PlayOneShot(audioManager.diePlayer, 2f);
    }
}
