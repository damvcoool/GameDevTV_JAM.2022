using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;

    [SerializeField] private Vector2 bulletForce;
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
              

        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Debug.Log($"{enemy.gameObject.name} has been hit");
            enemy.TakeDamage(Random.Range(bulletForce.y, bulletForce.x));
        }
            
        Destroy(gameObject);
    }
}
