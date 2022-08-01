using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    Vector3 directionVector;

    // Start is called before the first frame update
    void Start()
    {
        directionVector = Vector3.forward;
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
            if (directionVector.z == 1)
            {
                directionVector = Vector3.right;
            }
            else
            {
                directionVector = Vector3.forward;
            }
        }

        transform.position += directionVector * speed * Time.deltaTime;
    }
}
