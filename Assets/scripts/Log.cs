using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    public int turn = 1;
    public int test = 1;
    public float test2 = 1;
    public Animation animtest;

    void Start()
    {
        
    }

    void Update()
    {
        if(test == 0)
        { 
            GetComponent<Animator>().speed = test2;   
        }
    }

    private void FixedUpdate()
    {
        if(test == 0 && test2 > 0.1f)
        {
            test2 -= Time.deltaTime * 1.8f;
        }
        
    }
}
