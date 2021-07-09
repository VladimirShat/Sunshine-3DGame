using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Light_Control : MonoBehaviour
{
    public float sunSpeed = 30f;

    void Update()
    {
        //rotate sun
        if (Input.GetKey(KeyCode.Minus))
            transform.Rotate(Vector3.up, -sunSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Equals))
            transform.Rotate(Vector3.up, sunSpeed * Time.deltaTime);
    }
}