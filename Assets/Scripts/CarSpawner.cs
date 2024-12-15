using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarSpawner : MonoBehaviour
{

    public GameObject auto;
    public SpawnPoints[] sPoints;
    private List<int> probabilities = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        /*private int spawnNumb = SpawnPoints.;
        private int[] probList = new int[spawnNumb];*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BuildProbabilityList()
    {
        foreach (SpawnPoints point in sPoints)
        {
            int prob = Random.Range(0, 1);
            probabilities.Add(prob);
            
        }
    }

    void SpawnCars()
    {
        BuildProbabilityList();
        for (int i = 0; i < probabilities.Count; i++)
        {
            /*if (probabilities[i] > 0)
                Instantiate(auto, SpawnPoints[i].tra)*/
        }
    }

    void DespawnCars()
    {
        
    }
}

[System.Serializable]
public class SpawnPoints
{

    public string     name;
    public GameObject spawnPoint;
    public int        probability = 1;
}    

