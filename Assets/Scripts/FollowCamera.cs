using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform thingToFollow;
    void LateUpdate()
    {
        transform.position = thingToFollow.position + new Vector3(3,3,-10); 
    }
}
