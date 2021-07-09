using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public GameObject objectMove;
    public Vector3 startPosition;
    public Vector3 endPosition;
    private bool onTrigger = false;

    void Update()
    {
        if (onTrigger == false)
        {
            objectMove.transform.localPosition = Vector3.Lerp(objectMove.transform.localPosition, startPosition, 0.1f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onTrigger = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            objectMove.transform.localPosition = Vector3.Lerp(objectMove.transform.localPosition, endPosition, 0.1f * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onTrigger = false;
        }
    }
}
