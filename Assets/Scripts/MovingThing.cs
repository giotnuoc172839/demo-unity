using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingThing : MonoBehaviour
{
    [SerializeField] PlatformReset platformReset;

    private void Start()
    {
        platformReset = GameObject.Find("/Grid/Platforms").GetComponent<PlatformReset>();
    }
    void Update()
    {
        float speed = platformReset.moveSpeed;
        transform.Translate(-speed * Time.deltaTime, 0f, 0f);
    }
}
