using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    CarQueue carQueue;

    private void Start()
    {
        carQueue = CarQueue.Instance;
    }

    private void FixedUpdate()
    {
        carQueue.SpawnFromPool("car", transform.position, Quaternion.identity);

    }
}