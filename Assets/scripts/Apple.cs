using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Apple : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Destroyapple()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        for (int i = 0; i< 2; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
        ThrowHalfApple();
    }

    public void ThrowHalfApple()
    {
        int for0 = Random.Range(220, 220);
        int for1 = Random.Range(-220, -220);
        this.gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(new Vector2(for0, 450));
        this.gameObject.transform.GetChild(1).GetComponent<Rigidbody2D>().AddForce(new Vector2(for1, 450));
    }

}
