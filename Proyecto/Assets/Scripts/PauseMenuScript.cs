using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject aim;
    public GameObject player;
    private AudioSource playerAudio;

    private void Start()
    {
        playerAudio = player.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();

            }
            else
            {
                Pause();

            }
        } 
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        aim.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerAudio.volume = 1f;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        aim.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerAudio.volume = 0f;
    }

    public void returnMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
