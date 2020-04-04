using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailSpawner : MonoBehaviour
{
    public GameObject rail;
    public float count = 5;
    public float flop;

    // Update is called once per frame
    void Update()
    {
        if (count < 0)
        {
            
            count = 5;
            Instantiate(rail);
        }
        
        rail.transform.position = transform.position;
        flop = Time.deltaTime;
        count -= Time.deltaTime;
    }
}
