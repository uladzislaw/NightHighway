using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class CameraController : MonoBehaviour
{
    [Tooltip("camera positions")] 
    [SerializeField] Transform[] povs;
    [Tooltip("camera following's speed")]
    [SerializeField] private float speed;

    private int index = 0;
    private Vector3 target;

    public TMP_Text txt;

    public Camera cam;

    public string score;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            index = 0;
            cam.fieldOfView = 60f;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            index = 1;
            cam.fieldOfView = 40f;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) index = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha4)) index = 3;

        target = povs[index].position;
        
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        transform.forward = povs[index].forward;
        score = ((int)transform.position.x).ToString();
        txt.text = score;
    }

    private void FixedUpdate()
    {
        /*transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        transform.forward = povs[index].forward;*/
    }

    public void ChangePov()
    {
        int indx = Random.Range(0, 4);
        target = povs[index].position;
        
        return;
    }
}
