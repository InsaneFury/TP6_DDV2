using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsGroup : MonoBehaviour
{
    public float setlifeTime = 6f;

    private void Start()
    {
        lifeTime(setlifeTime);
    }

    void lifeTime(float time)
    {
        Destroy(gameObject, time);
    }
}
