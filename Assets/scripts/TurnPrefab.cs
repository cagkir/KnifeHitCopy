using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurnPrefab : MonoBehaviour
{
    public float forz;

    void Start()
    {
        forz = UnityEngine.Random.Range(-5, 5f);
    }

    void Update()
    {
        this.gameObject.GetComponent<Transform>().Rotate(new Vector3(0, 0, forz));
    }
}
