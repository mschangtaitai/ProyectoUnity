using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int life = 100;
    public Text lifeText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = life.ToString(); 
        if (life == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
