using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Read : MonoBehaviour
{
    public GameObject readPanel;
    public GameObject player;

    void OnMouseDown()
    {
        readPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerLook p = player.GetComponent<PlayerLook>();
        p.enabled = false;
        Time.timeScale = 0f;
    }

    public void Cancel()
    {
        readPanel.SetActive(false);
        PlayerLook p = player.GetComponent<PlayerLook>();
        p.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}
