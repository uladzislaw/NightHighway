using System;
using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Playables;
using Random = UnityEngine.Random;
using TMPro;

public class LevelController : MonoBehaviour
{
    // public Runner runner;
    
    public LevelPiece[] levelPieces;
    public Transform _camera;
    public int drawDistance;

    public float pieceLength;
    //public float speed;

    // public TextMeshProUGUI scoreText;
    // float score;

    private Queue<GameObject> activePieces = new Queue<GameObject>();
    private List<int> probabilityList = new List<int>();

    int currentCamStep = 0;
    int lastCamStep = 0;
    
    private void Start()
    {
        
        BuildProbabilityList();
        
        //spawn starting level pieces
        for (int i = 0; i < drawDistance; i++)
        {
            SpawnNewLevelPiece();
        }

        currentCamStep = (int)(_camera.transform.position.x / pieceLength);
        lastCamStep = currentCamStep;
    }

    private void Update()
    {
        // if (runner.hasDied)
        //     return;

        // score += speed * Time.deltaTime;
        // scoreText.text = Mathf.RoundToInt(score).ToString();
        
        // _camera.transform.position = Vector3.MoveTowards(_camera.transform.position,
        //     _camera.transform.position + Vector3.right, Time.deltaTime * speed);
        
        currentCamStep = (int)(_camera.transform.position.x / pieceLength);
        if (currentCamStep != lastCamStep)
        {
            lastCamStep = currentCamStep;
            DespawnLevelPiece();
            SpawnNewLevelPiece();
            
        }
    }

    void SpawnNewLevelPiece()
    {
        int pieceIndex = probabilityList[Random.Range(0, probabilityList.Count)];
        GameObject newLevelPiece = Instantiate(levelPieces[pieceIndex].prefab, new Vector3((currentCamStep + activePieces.Count) * pieceLength, 0f, 0f),
            Quaternion.identity);
        activePieces.Enqueue(newLevelPiece);
    }

    void DespawnLevelPiece()
    {
        GameObject oldLevelPiece = activePieces.Dequeue();
        Destroy(oldLevelPiece);
    }

    void BuildProbabilityList()
    {
        int index = 0;
        foreach (LevelPiece piece in levelPieces)
        {
            for (int i = 0; i < piece.probability; i++)
            {
                probabilityList.Add(index);
            }

            index++;
        }
    }
}

[System.Serializable]
public class LevelPiece
{

    public string name;
    public GameObject prefab;
    public int probability = 1;
}
