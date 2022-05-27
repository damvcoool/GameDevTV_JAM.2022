using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevJAM
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 10;

        private Rigidbody rb;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * bulletSpeed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Enemy>(out Enemy enemy))
            {
                if (enemy != null)
                {
                    enemy.DoDamage();
                }
            }
            Destroy(this.gameObject);
        }
    }
}