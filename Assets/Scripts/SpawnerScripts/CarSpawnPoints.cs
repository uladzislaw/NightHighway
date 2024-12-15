using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnPoints : MonoBehaviour
{
    public GameObject car;
    private GameObject carSpawned;
    private int probability;
    // Start is called before the first frame update
    void Start()
    {
        probability = Random.Range(0, 2);
        //Debug.Log(probability);
        if (probability == 1)
            spawnCar();
    }

    void spawnCar()
    {
        if (gameObject.transform.rotation.y > 0)
        {
            carSpawned = Instantiate(car, gameObject.transform.position, Quaternion.Euler(0, 180, 0));
        }
        else
        {
            carSpawned = Instantiate(car, gameObject.transform.position, Quaternion.identity);
        }
            
    }
}
