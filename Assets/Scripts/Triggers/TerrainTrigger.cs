using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTrigger : MonoBehaviour
{
    public GameObject terrain;
    public GameObject otherTerrains;
    public GameObject startLocation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            terrain.GetComponent<Terrain>().enabled = true;
            startLocation.SetActive(false);
            otherTerrains.SetActive(true);
        }
    }
}
