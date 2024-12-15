using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{

    public Collider coll;
    public GameObject screen;

    //public TMP_Text score_text;
    
    void Start()
    {
        coll = this.GetComponent<Collider>();
        
    }
    

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "npc_Car")
        {
            //Debug.Log(other.gameObject.tag);
            StartCoroutine(GameOvr());
        }
    }

    public IEnumerator GameOvr()
    {
        //Time.timeScale = 0;
        screen.SetActive(true);
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
