using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject tempParent;
    public float canHoldDistance;
    public float throwForce = 600;

    private GameObject item;
    private Vector3 objectPos;
    private float distance;
    private bool isHolding = false;

    private void Start()
    {
        item = gameObject;
    }

    void Update()
    {
        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);

        //breaking the connection
        if (distance >= canHoldDistance)
        {
            isHolding = false;
        }

        if (isHolding == true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            if (Input.GetMouseButtonDown(1))
            {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }
        }
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }

    private void OnMouseDown()
    {
        if (distance <= canHoldDistance)
        {
            isHolding = true;

            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;

            item.transform.SetParent(tempParent.transform);
        }
    }

    private void OnMouseUp()
    {
        isHolding = false;
    }
}
