using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogAnim : MonoBehaviour
{
    public float scale;

    void Start()
    {
        this.gameObject.GetComponent<Transform>().localScale = new Vector3(scale, scale, scale);
    }

    void Update()
    {
        if(scale < 1)
        {
            scale += 0.1f;
            this.gameObject.GetComponent<Transform>().localScale = new Vector3(scale, scale, scale);
        }
        
    }
}
