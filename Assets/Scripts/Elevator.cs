using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    enum ElevatorStates{Up, Down, Stop};
    ElevatorStates states;

    public Transform top;
    public Transform bottom;

    public float smooth;

    Vector3 newPos;

    bool hasRider;

    // Start is called before the first frame update
    void Start()
    {
        states = ElevatorStates.Stop;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.U) && hasRider)
        {
            states = ElevatorStates.Up;
        }

        if (Input.GetKeyDown(KeyCode.D) && hasRider)
        {
            states = ElevatorStates.Down;
        }

        FSM();
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

    void FSM()
    {
        if(states == ElevatorStates.Down)
        {
            newPos = bottom.position;
            transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        }

        if (states == ElevatorStates.Up)
        {
            newPos = top.position;
            transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        }

        if (states == ElevatorStates.Stop)
        {

        }
    }
}
