using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    enum PlatformStates{Up, Down, Stop};
    PlatformStates states;

    public Transform start;
    public Transform end;

    public float smooth;

    Vector3 newPos;

    bool hasRider;

    // Start is called before the first frame update
    void Start()
    {
        states = PlatformStates.Stop;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(hasRider)
        {
            states = PlatformStates.Up;
        }

        if (!hasRider)
        {
            states = PlatformStates.Down;
        }

        MovePlatform();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = gameObject.transform;
            hasRider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
            hasRider = false;
        }
    }

    void MovePlatform()
    {
        if(states == PlatformStates.Down)
        {
            newPos = start.position;
            transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        }

        if (states == PlatformStates.Up)
        {
            newPos = end.position;
            transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        }

        if (states == PlatformStates.Stop)
        {

        }
    }
}
