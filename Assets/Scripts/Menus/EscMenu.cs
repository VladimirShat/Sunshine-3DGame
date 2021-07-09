using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public KeyCode showMenuKey = KeyCode.Escape;
    public GameObject mainCamera;
    public GameObject player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if(mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }

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

            MouseLook ml = mainCamera.GetComponent<MouseLook>();
            ml.enabled = false;
            MouseLook p = player.GetComponent<MouseLook>();
            p.enabled = false;

            Time.timeScale = 0f;
        }
    }

    public void Cancel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        menuPanel.SetActive(false);

        MouseLook ml = mainCamera.GetComponent<MouseLook>();
        ml.enabled = true;
        MouseLook p = player.GetComponent<MouseLook>();
        p.enabled = true;

        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
