using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    //[SerializeField] public GameObject impactVFX;
    //[SerializeField] public GameObject spawnVFX;
    //[SerializeField] public AudioClip impactSFX;
    //[SerializeField] public AudioClip spawnSFX;
    private Rigidbody bulletRigidBody;



    private void Awake()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        bulletRigidBody.velocity = transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Target>() != null)
            Debug.Log($"Target {other.name} has been hit");
        Destroy(gameObject);
    }
}
