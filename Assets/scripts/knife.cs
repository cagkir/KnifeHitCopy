using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class knife : MonoBehaviour
{
    public GameObject manager;
    public int locked = 1;
    public int control = 0;
    public float opacity = 0;
    public Collider2D colli;

    void Start()
    {
        var color = new UnityEngine.Color(255, 255, 255, opacity);
        this.GetComponent<SpriteRenderer>().color = color;
        manager = GameObject.FindGameObjectWithTag("Manager");
        if (manager.GetComponent<manager>().winlose == true)
        {
            Destroy(this.gameObject);
        }
    }


    void Update()
    {
        var color = new UnityEngine.Color(255, 255, 255, opacity);
        this.GetComponent<SpriteRenderer>().color = color;
        manager = GameObject.FindGameObjectWithTag("Manager");
        if(locked == 0)
        {
            this.gameObject.GetComponent<Transform>().position += new Vector3(0, 0.07f, 0);
        }
    }

    private void FixedUpdate()
    {
        opacity += Time.deltaTime * 15;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Passive" && manager.GetComponent<manager>().TotalKnife > 0)
        {
            colli = collision;
            KnifeHitKnife();
        }
        else if (collision.tag == "Log" && control == 0)
        {
            colli = collision;
            KnifeHitLog();
        }
        else if(collision.tag == "Apple")
        {
            colli = collision;
            KnifeHitApple();
        }
    }

    public void KnifeHitKnife()
    {
        Debug.Log("        " + colli.gameObject.tag);
        control = 1;
        manager.GetComponent<manager>().lose();
        Destroy(this);
    }

    public void KnifeHitLog()
    {
        Debug.Log("        " + colli.gameObject.tag);
        manager.GetComponent<manager>().Stick();
        manager.GetComponent<manager>().KnifeHitLog.Play();
        manager.GetComponent<manager>().particleSystem.Play();
        Destroy(this.gameObject);

        if (manager.GetComponent<manager>().winlose == false)
        {
            manager.GetComponent<manager>().newActiveKnife();
        }
    }

    public void KnifeHitApple()
    {
        Debug.Log("        " + colli.gameObject.tag);
        colli.gameObject.GetComponent<Apple>().Destroyapple();
        manager.GetComponent<manager>().AppleCountAdd();
    }

}