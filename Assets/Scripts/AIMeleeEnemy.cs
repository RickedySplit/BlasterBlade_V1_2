using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMeleeEnemy : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;

    //public float maxChaseRange;

    public LayerMask PlayerMask;

    //States
    public float sightRange;
    public bool playerInSightRange;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Atan2 is used to find the angle between two points
        //Rad2Deg converts from Radiant to Degrees (Might want to re-visit Bullet Spread Script with this info?)

        playerInSightRange = Physics2D.OverlapCircle(transform.position, sightRange, PlayerMask);

        //if (distance < maxChaseRange)
        if (playerInSightRange == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            //MoveTowards makes the GameObject move towards the other gameobject
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            //This makes enemy rotate towards the player
            //Tried using Vector2.up, but this just makes the enemy stretch and not work?
            //Parts of this script may be able to be used in the healthbar script, so it stays above the object maybe? Unsure, will need to research more.
        }
    }
}
