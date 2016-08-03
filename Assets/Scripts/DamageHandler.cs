﻿using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour
{

    public float health = 5;
    public float damage = 2;


    // Use this for initialization
    void Start()
    {
        


    }


    void OnTriggerEnter2D()
    {
        Debug.Log("Trigger!");

        health = health - damage;
    }


    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
