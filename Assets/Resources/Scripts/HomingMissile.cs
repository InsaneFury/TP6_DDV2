using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{

    public float turn;
    public float missileVelocity;
    TurretController player;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = TurretController.Get();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.forward * missileVelocity;
        Quaternion rotation = Quaternion.LookRotation(player.target - transform.position);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, turn));
    }
}
