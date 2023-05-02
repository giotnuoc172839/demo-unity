using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformReset : MonoBehaviour
{
    private Vector2 startPos;
    public float moveSpeed = 1f;

    float length;
    void Start()
    {
        startPos = transform.position;
        length = GetComponent<TilemapRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.Translate(- moveSpeed * Time.deltaTime, 0f,0f);
        if(Vector2.Distance(startPos,(Vector2)transform.position) >= length)
        {
            transform.position = startPos;
        }
    }
}
