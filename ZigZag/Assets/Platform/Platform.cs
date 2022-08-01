using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    MeshRenderer meshRenderer;
    int index;
    float _lerpTime = 0.5f;
    float _changer;

    Color[] colorList = new Color[] {Color.red, Color.magenta, Color.blue, Color.yellow};

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

    }

    private void OnEnable()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.isKinematic = true;
        rb.useGravity = false;
        
        
    }

    private void Update()
    {
        meshRenderer.material.color = Color.Lerp(meshRenderer.material.color, colorList[index], _lerpTime * Time.deltaTime);
        _changer = Mathf.Lerp(_changer, 1f, _lerpTime * Time.deltaTime);

        if(_changer > 0.9f)
        {
            _changer = 0;
            index++;

            if(index >= colorList.Length)
            {
                index = 0;
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
