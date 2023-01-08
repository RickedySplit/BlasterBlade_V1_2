using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawningV2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        GameObject hitObject = other.gameObject;
        if (hitObject.CompareTag("WallTag"))
        {
            Debug.Log("Hit Wall");
            hitObject.GetComponent<InvisWallScriptV2>().TurnToDoor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
