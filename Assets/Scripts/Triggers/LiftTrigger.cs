using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftTrigger : MonoBehaviour
{
    public GameObject objectMove;
    public float startPosition;
    public float endPosition;

    private bool onTrigger = false;

    private void Update()
    {
        if (!onTrigger)
        {
            objectMove.transform.localPosition = Vector3.Lerp(objectMove.transform.localPosition, new Vector3(objectMove.transform.localPosition.x, startPosition, objectMove.transform.localPosition.z), 0.1f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onTrigger = true;
            other.transform.parent = objectMove.transform;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            objectMove.transform.localPosition = Vector3.Lerp(objectMove.transform.localPosition, new Vector3(objectMove.transform.localPosition.x, endPosition, objectMove.transform.localPosition.z), 0.1f * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onTrigger = false;
            other.transform.parent = null;
        }
    }
}
