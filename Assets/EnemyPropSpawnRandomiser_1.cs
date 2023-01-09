using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPropSpawnRandomiser_1 : MonoBehaviour
{
    public GameObject[] things; //Objects Array
    public GameObject chosenThing; //Objects Chosen to be Instantiated
    int index; //Number for Random.Range

    // Start is called before the first frame update
    void Start()
    {
        index = Random.Range(0, things.Length);
        chosenThing = things[index];
        Instantiate(chosenThing, transform.position, transform.rotation);

        //Adds enemies, finally
        //It's 23:39 (08/01/2023) as I type this, whoever is reading this: How was your Christmas?
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
