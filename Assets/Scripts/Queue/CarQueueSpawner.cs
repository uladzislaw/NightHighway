using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random=UnityEngine.Random;

public class CarQueueSpawner : MonoBehaviour
{
    CarQueue carQueue;

    private int probability;
    private int carProbability;
    
    private void Start()
    {
        carQueue = CarQueue.Instance;
        
        probability = Random.Range(0, 2);
        //Debug.Log(probability);
        if (probability == 1)
        {
            SpawnRandomCar();
            
        }
    }

    private void SpawnRandomCar()
    {
        carProbability = Random.Range(0, CarQueue.Instance.pools.Count);
        if (transform.rotation.y > 0)
        {
            carQueue.SpawnFromPool(CarQueue.Instance.poolDictionary.Keys.ElementAt(carProbability), transform.position, Quaternion.Euler(0, 180, 0));
        }
        else
        {
            carQueue.SpawnFromPool(CarQueue.Instance.poolDictionary.Keys.ElementAt(carProbability), transform.position, Quaternion.identity);
        }
    }
    
}

