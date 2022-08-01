using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    Vector3 _directionVector;

    // Start is called before the first frame update
    void Start()
    {
        _directionVector = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }


    void PlayerMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_directionVector.z == 1)
            {
                _directionVector = Vector3.right;
            }
            else
            {
                _directionVector = Vector3.forward;
            }
        }

        transform.position += _directionVector * speed * Time.deltaTime;
    }
}
