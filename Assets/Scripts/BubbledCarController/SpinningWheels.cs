using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningWheels : MonoBehaviour
{

    public TrailRenderer[] trails;
    public GameObject[] wheelsToRotate;
    public float rotationSpeed;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalAxis = Input.GetAxisRaw("Vertical");
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        
        foreach (var wheel in wheelsToRotate)
        {
            wheel.transform.Rotate(0, 0, Time.deltaTime * verticalAxis * rotationSpeed, Space.Self);
        }

        if (horizontalAxis > 0)
        {
            anim.SetBool("goLeft", false);
            anim.SetBool("goRight", true);
        }
        
        else if (horizontalAxis < 0)
        {
            anim.SetBool("goLeft", true);
            anim.SetBool("goRight", false);
        }
        else
        {
            anim.SetBool("goLeft", false);
            anim.SetBool("goRight", false);
        }

        if (horizontalAxis != 0)
        {
            foreach (var trail in trails)
            {
                trail.emitting = true;
            }
        }
        else
        {
            foreach (var trail in trails)
            {
                trail.emitting = false;
            }
        }
    }
}
