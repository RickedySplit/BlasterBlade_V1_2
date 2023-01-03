using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawningV1 : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject chosenLevel;
    int index;
    // Awake is called when the script instance is being loaded.
    void Awake()
    {
        index = Random.Range (0, levels.Length);
        chosenLevel = levels[index];
        Instantiate(chosenLevel, transform.position, transform.rotation, transform.parent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
