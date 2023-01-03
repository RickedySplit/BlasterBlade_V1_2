using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDeleteMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void selfDeleto()
    {
        Destroy(gameObject);
    }
}
