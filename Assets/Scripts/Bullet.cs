using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public GameObject enemyHitEffect;
    public GameObject crateHitEffect;
    public float damage = 5;


    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitObject = collision.gameObject;
        if (hitObject.CompareTag("Enemy"))
        {
            hitObject.GetComponent<Target>().TakeDamage(damage);
            Instantiate(enemyHitEffect, transform.position, Quaternion.identity);
        }
        else if (hitObject.CompareTag("PracticeEnemy"))
        {
            hitObject.GetComponent<Target>().TakeDamage(damage);
            Instantiate(crateHitEffect, transform.position, Quaternion.identity);
        }


        if (hitEffect != null) //Will instantiate hit effect, only if there is one (to avoid errors)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
