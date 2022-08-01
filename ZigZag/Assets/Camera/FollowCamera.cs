using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 _offset;


    void Start()
    {
        _offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        transform.position = player.position + _offset;
    }
}
