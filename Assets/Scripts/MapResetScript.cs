using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapResetScript : MonoBehaviour
{

    public GameObject mapPrefab;
    public GameObject currentMap;

    // Start is called before the first frame update
    void Start()
    {
        //SpawnMap();
        //GameObject currentMap;
        GameObject currentMap = Instantiate(mapPrefab, transform.position, transform.rotation);
        //GameObject currentMap = (GameObject)Instantiate(mapPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //GameObject currentMap;
            GameObject currentMap = Instantiate(mapPrefab, transform.position, transform.rotation);
            Destroy(currentMap);


            //currentMap.GetComponent<selfDelete>().selfDeleto();
            //DestroyMap();
            //SpawnMap();
        }
    }

    void SpawnMap()
    {
        //GameObject currentMap;
        //currentMap = Instantiate(mapPrefab, transform.position, transform.rotation);
    }
    
    //void DestroyMap()
    //{
    //    GameObject currentMap;
    //    if (mapPrefab != null)
    //    {
    //        Destroy(currentMap);
    //    }
    //}
}
