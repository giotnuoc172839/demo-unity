using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{

    [SerializeField] private GameObject[] thingToSpawn;
    [SerializeField] private float timeSpawnMin;
    [SerializeField] private float timeSpawnMax;

    float time;


    private void Start()
    {
        time = 2f;
    }

    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0f)
        {
            GameObject obj = thingToSpawn[Random.Range(0, thingToSpawn.Length)];
            Instantiate(obj, new Vector3(transform.position.x, obj.transform.position.y, obj.transform.position.z), Quaternion.identity);
            time = Random.Range(timeSpawnMin,timeSpawnMax);
            Debug.Log(time);
        }  
    }
}
