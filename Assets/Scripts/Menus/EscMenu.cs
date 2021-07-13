using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public KeyCode showMenuKey = KeyCode.Escape;
    public GameObject player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(showMenuKey))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            menuPanel.SetActive(true);

            PlayerLook pLook = player.GetComponent<PlayerLook>();
            pLook.enabled = false;

            Time.timeScale = 0f;
        }
    }

    public void Cancel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        menuPanel.SetActive(false);

        PlayerLook pLook = player.GetComponent<PlayerLook>();
        pLook.enabled = true;

        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
