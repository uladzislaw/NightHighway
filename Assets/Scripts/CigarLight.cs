using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CigarLight : MonoBehaviour
{
    public Animator anim;
    
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("Light", true);
    }

}
