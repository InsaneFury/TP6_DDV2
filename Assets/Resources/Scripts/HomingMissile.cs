using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public float turn;
    public float missileVelocity;
    TurretController player;
    Rigidbody rb;
    public Vector3 missileTarget;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = TurretController.Get();
        missileTarget = player.target;
        Invoke("DestroyMissile", 4f);
    }

    void FixedUpdate()
    {
        missileTarget = player.target;
        rb.velocity = transform.forward * missileVelocity;
        Quaternion rotation = Quaternion.LookRotation(missileTarget - transform.position);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, turn));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            collision.collider.GetComponent<Enemy>().Die();
            DestroyMissile();
        }
    }

    void DestroyMissile()
    {
        Destroy(gameObject);
    }
}
