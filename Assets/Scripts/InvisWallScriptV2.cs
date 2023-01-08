using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisWallScriptV2 : MonoBehaviour
{
    public GameObject[] doorVariants;
    public GameObject selectedDoor;
    int index;
    public GameObject wall;
    public bool isDoor = false;

    public float stuffSpawnDelay = 1.5f;
    public float countdown;
    public bool hasSpawned = false;

    void Start()
    {
        countdown = stuffSpawnDelay;
    }

    public void TurnToDoor()
    {
        isDoor = true;
    }

    void WallOrDoorSpawn()
    {
        if((isDoor == false) && (hasSpawned == false))
        {
            Instantiate(wall, transform.position, transform.rotation);
            hasSpawned = true;
        }
        if((isDoor == true) && (hasSpawned == false))
        {
            index = Random.Range(0, doorVariants.Length);
            selectedDoor = doorVariants[index];
            Instantiate(selectedDoor, transform.position, transform.rotation);
            hasSpawned = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        {
            if ((countdown <= 0f) && (hasSpawned == false))
            {
                WallOrDoorSpawn();
            }
        }
    }
}
