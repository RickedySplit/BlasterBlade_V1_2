using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Rigidbody2DExtensions; //Yeah Yeah, this is stolen from a reddit post, shut up

public static class Rigidbody2DExtensions
{
    public static void AddExplosionForce2D(this Rigidbody2D rb, Vector3 explosionOrigin, float explosionForce, float explosionRadius)
    {
        Vector3 direction = rb.transform.position - explosionOrigin;
        float forceFalloff = 1 - (direction.magnitude / explosionRadius);
        rb.AddForce(direction.normalized * (forceFalloff <= 0 ? 0 : explosionForce) * forceFalloff);
    }
}


public class Grenade : MonoBehaviour
{
    public float explodeDelay = 3f;
    float countdown;
    bool hasExploded = false;
    public GameObject explosionEffect;
    public float blastRadius = 5;
    public float explosiveForce = 700;
    public float damage = 5f;

    // Start is called before the first frame update     

    void Start()
    {
        countdown = explodeDelay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        {
            if (countdown <= 0f && !hasExploded)
            {
                Explode();
            }
        }
    }

    void AddExplosionForce2D(Vector3 explosionOrigin, float explosionForce, float explosionRadius)
    {
        Vector3 direction = transform.position - explosionOrigin;
        float forceFalloff = 1 - (direction.magnitude / explosionRadius);
        GetComponent<Rigidbody2D>().AddForce(direction.normalized * (forceFalloff <= 0 ? 0 : explosionForce) * forceFalloff);
    }


    void Explode()
    {
        
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Debug.Log("Grenade Exploded");
        hasExploded = true;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastRadius);

        foreach (Collider2D nearbyObject in colliders)
        {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if (nearbyObject.CompareTag("Enemy"))
                {
                    nearbyObject.GetComponent<Target>().TakeDamage(damage);
                    //Instantiate(enemyHitEffect, transform.position, Quaternion.identity);
                }
                else if (nearbyObject.CompareTag("PracticeEnemy"))
                {
                    nearbyObject.GetComponent<Target>().TakeDamage(damage);
                    //Instantiate(crateHitEffect, transform.position, Quaternion.identity);
                }

                rb.AddExplosionForce2D(transform.position, explosiveForce, blastRadius);
            }
        }

        Destroy(gameObject);
    }
}
