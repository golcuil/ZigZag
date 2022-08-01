using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    Vector3 _directionVector;
    float _dummy = 0; // to check score / 100 constant value;
    float _difficultyInterval = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        _directionVector = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        SpeedCheck();
        PlayerMove();
    }

    void SpeedCheck()
    {
        float divided = Mathf.Ceil(UIHandler.Instance.Score / 100);

        if(divided - _dummy > 0)
        {
            speed += _difficultyInterval;
            _dummy = divided;
        } 

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
