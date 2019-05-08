using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [Header("RocketSettings")]
    public GameObject missilePrefab;
    private void Update()
    {
        
    }

    public void LaunchMissile()
    {
        GameObject currentMissile;
        currentMissile = Instantiate(missilePrefab, transform.position, Quaternion.identity);
    }
}
