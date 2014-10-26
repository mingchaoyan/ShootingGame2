﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    private float currentSpeed;

    private float minScale = 0.5f;
    private float maxScale = 1.2f;
    private float curScaleX;
    private float curScaleY;
    private float curScaleZ;

    float x, y, z = 0;

    // Use this for initialization
    void Start()
    {
        InitPositionAndSpeed();
    }
	
    // Update is called once per frame
    void Update()
    {
        float toMove = currentSpeed * Time.deltaTime;
        transform.Translate(Vector3.down * toMove);
        if (transform.position.y < -4.5)
        {
            Player.missed ++;
            InitPositionAndSpeed();
        }
	
    }
    public void InitPositionAndSpeed()
    {
        currentSpeed = Random.Range(minSpeed, maxSpeed);
        curScaleX = Random.Range(minScale, maxScale);
        curScaleY = Random.Range(minScale, maxScale);
        curScaleZ = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(curScaleX, curScaleY, curScaleZ);
        x = Random.Range(-8.5f, 8.5f);
        y = 6.5f;
        transform.position = new Vector3(x, y, z);
    }
}
