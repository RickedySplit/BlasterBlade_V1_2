using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRandomisation : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject chosenLevel;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        index = Random.Range (0, levels.Length);
        chosenLevel = levels[index];
        chosenLevel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
