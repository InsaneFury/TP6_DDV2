using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public bool isUnderAttack = false;

    public GameObject weapons;
    public float dropSpeed = 0.6f;
    public float delayOnFloor = 0.2f;

    Rigidbody rb;
    TurretController player;
    bool enemyTargeted = false;

    void Start()
    {
        player = TurretController.Get();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity * dropSpeed;
        if (enemyTargeted)
        {
            player.target = transform.position;
        }  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            Debug.Log("Lose 1 life");
            Invoke("Die",delayOnFloor);
        }
    }

    private void OnMouseDown()
    {
        enemyTargeted = true;
    }

    public void Die()
    {
        SpawnWeapons();
        Destroy(gameObject);
    }

    void SpawnWeapons()
    {
        Instantiate(weapons, transform.position, Quaternion.identity);
    }
}
