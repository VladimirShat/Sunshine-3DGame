using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public float canHoldDistance = 1.5f;
    public float throwForce = 600f;

    public bool isHolding = false;
    private Vector3 objectPos;

    public void PickUp(GameObject tempParent)
    {
        isHolding = true;

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().detectCollisions = true;

        transform.SetParent(tempParent.transform);
    }

    public void DePickUp()
    {
        objectPos = transform.position;
        transform.SetParent(null);
        GetComponent<Rigidbody>().useGravity = true;
        transform.position = objectPos;
    }
}
