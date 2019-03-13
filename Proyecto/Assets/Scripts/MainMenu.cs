using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Background;
    public Slider Slider;
    private AudioSource source;
    public GameObject panel;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        source = panel.GetComponent<AudioSource>();

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Pallet Town");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
   
}
