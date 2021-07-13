using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    public GameObject hand;

    private float distance;
    Selectable selectable;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            //debug ray
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.yellow);

            selectable = hitInfo.collider.gameObject.GetComponent<Selectable>();

            if (selectable)
            {
                distance = Vector3.Distance(hand.transform.position, hitInfo.transform.position);

                if (Input.GetMouseButtonDown(0) && distance <= selectable.canHoldDistance)
                {
                    selectable.PickUp(hand);
                }

                if (Input.GetMouseButtonUp(0))
                {
                    selectable.isHolding = false;
                }

                //breaking the connection
                if (distance >= selectable.canHoldDistance)
                {
                    selectable.isHolding = false;
                }

                if (selectable.isHolding)
                {
                    selectable.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    selectable.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

                    if (Input.GetMouseButtonDown(1))
                    {
                        selectable.GetComponent<Rigidbody>().AddForce(hand.transform.forward * selectable.throwForce);
                        selectable.isHolding = false;
                    }
                }
                else
                {
                    selectable.DePickUp();
                }
            }
        }
    }
}