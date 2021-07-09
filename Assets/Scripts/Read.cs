using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Read : MonoBehaviour
{
    public GameObject plane;
    public GameObject Camera;
    public GameObject Person;

    void OnMouseDown()
    {
        plane.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MouseLook ml = Camera.GetComponent<MouseLook>();
        ml.enabled = false;
        MouseLook p = Person.GetComponent<MouseLook>();
        p.enabled = false;
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Cancel()
    {
        plane.SetActive(false);
        MouseLook ml = Camera.GetComponent<MouseLook>();
        ml.enabled = true;
        MouseLook p = Person.GetComponent<MouseLook>();
        p.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}
