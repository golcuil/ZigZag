using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    MeshRenderer _meshRenderer;
    int _index;
    float _lerpTime = 0.5f;
    float _changer;

    Color[] colorList = new Color[] {Color.red, Color.magenta, Color.blue, Color.yellow};

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

    }

    private void OnEnable()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.isKinematic = true;
        rb.useGravity = false;
        
        
    }

    private void Update()
    {
        _meshRenderer.material.color = Color.Lerp(_meshRenderer.material.color, colorList[_index], _lerpTime * Time.deltaTime);
        _changer = Mathf.Lerp(_changer, 1f, _lerpTime * Time.deltaTime);

        if(_changer > 0.9f)
        {
            _changer = 0;
            _index++;

            if(_index >= colorList.Length)
            {
                _index = 0;
            }
        }
    }

    IEnumerator FallSequence()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.isKinematic = false;
        rb.useGravity = true;
        
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);

    }

    private void OnCollisionExit(Collision collision)
    {
        UIHandler.Instance.IncreaseScore();
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FallSequence());

        }
    }
}
