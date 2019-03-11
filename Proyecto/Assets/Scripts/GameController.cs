using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int life = 100;
    public Text lifeUI;

    private void Update()
    {

    if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit) && hit.transform.CompareTag("Enemy")) 
            {
                Destroy(hit.transform.gameObject);
                Debug.Log("Hit");
            }
        }
    }
}
