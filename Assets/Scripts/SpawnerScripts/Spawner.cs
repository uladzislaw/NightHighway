 using System.Collections;
using System.Collections.Generic;
 using System.Linq;
 using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<CarSpawnPoints> _spawnPoints = new List<CarSpawnPoints>();
    private List<CarsForSpawn> _carsForSpawn = new List<CarsForSpawn>();
    // Start is called before the first frame update
    void Start()
    {
        _spawnPoints = FindObjectsOfType<CarSpawnPoints>().ToList();
        _carsForSpawn = FindObjectsOfType<CarsForSpawn>().ToList();
    }

    void SpawnCar()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
   
}
