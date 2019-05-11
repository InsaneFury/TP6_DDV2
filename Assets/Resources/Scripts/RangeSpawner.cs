﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSpawner : Singleton<RangeSpawner>
{
    [Header("SpawnerSettings")]
    public Vector3 center;
    public Vector3 size;
    
    public override void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        transform.position = RandomPosition();    
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
        Gizmos.DrawCube(center, size);
    }

    public Vector3 RandomPosition()
    {
        Vector3 pos = center + new Vector3(
        Random.Range(-size.x / 2, size.x / 2),
        Random.Range(-size.y / 2, size.y / 2),
        Random.Range(-size.z / 2, size.z / 2));
        return pos;
    }
}
