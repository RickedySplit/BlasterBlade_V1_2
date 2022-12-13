using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCenterV2 : MonoBehaviour
{
    public GameObject[] roomDirs;
    public GameObject selectedDir;
    int index;
    public bool roomIsSelected = false;
    public GameObject roomLight;


    public void RoomSelected()
    {
        if(roomIsSelected == false)
        {
            roomIsSelected = true;
            index = Random.Range(0, roomDirs.Length);
            selectedDir = roomDirs[index];
            Instantiate(selectedDir, transform.position, transform.rotation);
            roomLight.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
