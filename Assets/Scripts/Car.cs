using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class Car : MonoBehaviour
{
    private Animator _animator;
    public AnimationCurve jumpCurve;
    public Rigidbody _rigidbody;
    float jumpTimer;
    float yPos = 0f;
    bool _isJumping;
    public bool hasDied = false;

    //public float[] zPos;
    //private int zPosIndex = 1;
    public float speed = 5f;
    public float floorHeight;

    private float zLeft = 0.7f;
    private float zRight = -0.7f;

    private void Start()
    {
        //_animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        //Begin();
    }

    public void Begin()
    {
        _animator.SetBool("running", true);
    }

    private void Update()
    {
        
        /*if (Input.GetKeyDown(KeyCode.D))
            MoveRight();
        if (Input.GetKeyDown(KeyCode.A))
            MoveLeft();*/
        if (Input.GetKey(KeyCode.D))
            MoveRight();
        if (Input.GetKey(KeyCode.A))
            MoveLeft();
        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
            isJumping = true;

        if (isJumping)
        {
            yPos = jumpCurve.Evaluate(jumpTimer);
            jumpTimer += Time.deltaTime;

            if (jumpTimer > 1f)
            {
                jumpTimer = 0;
                isJumping = false;
            }
        }

        transform.position = UnityEngine.Vector3.MoveTowards(transform.position,
            new UnityEngine.Vector3( transform.position.x, floorHeight + yPos, transform.position.z), Time.deltaTime * speed);
    }

    bool isJumping
    {
        get { return _isJumping; }
        set
        {
            _isJumping = value;
            //_animator.SetBool("jumping", value);
        }
    }

    void MoveRight()
    {
        /*zPosIndex--;
        if (zPosIndex < 0)
        {
            zPosIndex = 0;
        */
        //}
        
        transform.position = UnityEngine.Vector3.MoveTowards(transform.position,
            new UnityEngine.Vector3( transform.position.x, floorHeight + yPos, zRight), Time.deltaTime * 0.4f * speed);
    }
    void MoveLeft()
    {
        /*zPosIndex++;
        if (zPosIndex > zPos.Length - 1)
        {
            zPosIndex = zPos.Length - 1;
        }*/
        
        transform.position = UnityEngine.Vector3.MoveTowards(transform.position,
            new UnityEngine.Vector3( transform.position.x, floorHeight + yPos, zLeft), Time.deltaTime * 0.4f * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasDied)
            return;
        if (other.tag == "Mobile")
            Die();
        Debug.Log("crash");
    }

    private void Die()
    {
        
        //_animator.SetTrigger("die");
        hasDied = true;
    }
}
