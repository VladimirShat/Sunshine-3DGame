using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject tempParent;
    public float canHoldDistance = 1f;
    public float throwForce = 600f;

    private Vector3 objectPos;
    private float distance;
    private bool isHolding = false;

    private void Start()
    {
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, tempParent.transform.position);

        //breaking the connection
        if (distance >= canHoldDistance)
        {
            isHolding = false;
        }

        if (isHolding == true)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }
        }
        else
        {
            objectPos = transform.position;
            transform.SetParent(null);
            GetComponent<Rigidbody>().useGravity = true;
            transform.position = objectPos;
        }
    }

    private void OnMouseDown()
    {
        if (distance <= canHoldDistance)
        {
            isHolding = true;

            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().detectCollisions = true;

            transform.SetParent(tempParent.transform);
        }
    }

    private void OnMouseUp()
    {
        isHolding = false;
    }
}
