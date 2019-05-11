using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public bool isUnderAttack = false;

    public GameObject weapons;
    public float dropSpeed = 0.6f;
    public int score = 10;

    Rigidbody rb;
    TurretController player;
    ScoreManager mScore;
    bool enemyTargeted = false;

    void Start()
    {
        mScore = ScoreManager.Get();
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
            mScore.lives--;
            Die();
        }
        if (collision.collider.CompareTag("HomingMissile"))
        {
            mScore.AddScore(score);
            Die();
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
