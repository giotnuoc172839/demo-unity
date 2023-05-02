using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private GameObject camPos;
    [SerializeField] private float parallaxEffectSpeed;
    private float length,startPosX;
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosX = transform.position.x;
    }

    void FixedUpdate()
    {
        float temp = camPos.transform.position.x * (1 - parallaxEffectSpeed);
        float distance = camPos.transform.position.x * parallaxEffectSpeed;

        transform.position = new Vector3(startPosX + distance, transform.position.y, transform.position.z);

        if(temp > startPosX + length)
        {
            startPosX += length;
        }else if(temp < startPosX - length)
        {
            startPosX -= length;
        }
    }
}
