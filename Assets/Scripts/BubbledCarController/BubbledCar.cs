using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbledCar : MonoBehaviour
{
    private float moveInput;
    private float turnInput;

    public GameObject BackLights;

    private bool isCarGrounded;

    public LayerMask groundLayer;

    private float normalDrag;
    public float modifiedDrag;
    
    public float alighToGroundTime;
    
    public float fwdSpeed;
    public float revSpeed;
    public float turnSpeed;
    
    public Rigidbody sphereRB;
    public Rigidbody carRB;

    public Joystick joystick_horiz;
    public Joystick joystick_vert;

    private void Start()
    {
        sphereRB.transform.parent = null;
        carRB.transform.parent = null;

        normalDrag = sphereRB.drag;
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        //moveInput = joystick_vert.Vertical;
        turnInput = Input.GetAxisRaw("Horizontal");
        //turnInput =  joystick_horiz.Horizontal;
        
        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;

        if (moveInput >= 0)
        {
            moveInput *= fwdSpeed;
            BackLights.SetActive(false);
        }
        else
        {
            moveInput *= revSpeed;
            BackLights.SetActive(true);
        }
        
        transform.position = sphereRB.transform.position;

        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        //float newRotation = turnInput * turnSpeed * Time.deltaTime * joystick_vert.Vertical;
        transform.Rotate(0, newRotation, 0, Space.World);

        RaycastHit hit;
        isCarGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1f, groundLayer);
        
        Quaternion toRotate = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotate, alighToGroundTime * Time.deltaTime);

        sphereRB.drag = isCarGrounded ? normalDrag : modifiedDrag;
    }

    private void FixedUpdate()
    {
        if (isCarGrounded)
        {
            sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
        }
        else
        {
            sphereRB.AddForce(transform.up * -40f);
        }
        carRB.MoveRotation(transform.rotation);
      
    }
}
