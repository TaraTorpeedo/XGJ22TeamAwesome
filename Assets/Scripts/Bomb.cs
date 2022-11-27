using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monitor"))
        {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            collision.rigidbody.AddExplosionForce(4000f, transform.position, 900f);
        }
    }

}
