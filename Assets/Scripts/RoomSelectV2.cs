using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelectV2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        GameObject hitObject = other.gameObject;
        Debug.Log(other.gameObject.name + " was Collided with");
        if (hitObject.CompareTag("RoomCenterTag"))
        {
            hitObject.GetComponent<RoomCenterV2>().RoomSelected();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
