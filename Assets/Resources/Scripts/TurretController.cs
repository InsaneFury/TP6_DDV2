using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : Singleton<TurretController>
{
    public Vector3 target;
    public Transform turretBase;
    public Transform turretCanion;
    public float speedBase = 1f;
    public float speedCanion = 2f;
    public float rayDistance = 100f;
    bool canAim = false;

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        target = Vector3.zero;
    }

    void Update()
    {
        moveBase();
        moveCanion();
        Shoot();
    }

    void moveBase()
    {
        Vector3 dir = (target - turretBase.position).normalized;
        Quaternion lookToRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = Quaternion.Lerp(turretBase.rotation, 
        lookToRotation, speedBase * Time.deltaTime).eulerAngles;

        turretBase.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void moveCanion()
    {
        Vector3 dir = (target - turretCanion.position).normalized;
        Quaternion lookToRotation = Quaternion.LookRotation(dir, Vector3.up);

        Vector3 rotation = Quaternion.Lerp(turretCanion.localRotation, 
        lookToRotation, speedCanion * Time.deltaTime).eulerAngles;

        turretCanion.localRotation = Quaternion.Euler(rotation.x, 0f, 0f);
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(turretCanion.position, turretCanion.forward, out hit, rayDistance))
        {
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                Debug.DrawRay(turretCanion.position, turretCanion.forward * hit.distance, Color.red);
                Debug.Log("Can Hit");
            }
        }
        else
        {
            Debug.DrawRay(turretCanion.position, turretCanion.forward * rayDistance, Color.white);
        }
    }
}
