using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    TurretController player;

    // Start is called before the first frame update
    void Start()
    {
        player = TurretController.Get();
    }

    private void OnMouseDown()
    {
        player.target = transform.position;
    }
}
