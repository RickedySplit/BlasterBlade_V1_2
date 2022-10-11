using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static Rigidbody2DExtensions;

public class Grenade : MonoBehaviour
{
    public float explodeDelay = 3f;
    float countdown;
    bool hasExploded = false;
    public GameObject explosionEffect;
    public float blastRadius = 5;
    public float explosiveForce = 700;

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
                rb.AddExplosionForce2D(transform.position, explosiveForce, blastRadius);
            }
        }

        Destroy(gameObject);
    }
}
