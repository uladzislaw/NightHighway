using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedCarChecking : MonoBehaviour, PoolObject
{
    private float rotat;
    
    public void OnObjectSpawn()
    {
        rotat = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotat > 0)
        {
            transform.position -= new Vector3(20, 0,0) * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(12, 0,0) * Time.deltaTime;
        }
        
        //Destroy(gameObject, 60f);
    }
}
