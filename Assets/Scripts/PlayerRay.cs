using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    private Selectable currentSelectable;

    void Update()
    {
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = transform.forward;

        //debug ray
        Debug.DrawRay(transform.position, transform.forward*10f, Color.yellow);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();
            if (selectable)
            {
                if (currentSelectable && currentSelectable != selectable)
                {
                    currentSelectable.Deselect();
                }
                currentSelectable = selectable;
                selectable.Select();
            }
            else if (currentSelectable)
            {
                currentSelectable.Deselect();
                currentSelectable = null;
            }
        }
        else if (currentSelectable)
        {
            currentSelectable.Deselect();
            currentSelectable = null;
        }
    }
}
