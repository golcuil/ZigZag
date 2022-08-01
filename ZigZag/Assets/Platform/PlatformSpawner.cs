using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] int poolSize = 50;

    Vector3 forwardSide;
    Vector3 rightSide;
    Vector3 _lastCoordinate;
    List<GameObject> pool = new List<GameObject>();

    [SerializeField] bool isAlive = true;

    public static PlatformSpawner Instance;

    void Awake()
    {
        Instance = this;
        GeneratePool();
        _lastCoordinate = new Vector3(6.5f, 0, 3.5f); // First Cube Position
        rightSide = new Vector3(0, 0, 3); // 3x3 square
        forwardSide = new Vector3(3, 0, 0);

    }

    private void Start()
    {
        StartCoroutine(SetPlatform());
    }

    void GeneratePool()
    {
        for(int i = 0; i < poolSize; i++)
        {
            GameObject prefabInPool = Instantiate(platformPrefab, transform.position, Quaternion.identity);
            prefabInPool.SetActive(false);
            pool.Add(prefabInPool);
        }
    }

    void GetPlatformFromPool()
    {
        int randomPos = Random.Range(0, 2);

        if(randomPos == 0)
        {
            foreach(var prefab in pool)
            {
                if (!prefab.activeInHierarchy)
                {
                    _lastCoordinate += rightSide;
                    prefab.transform.position = Vector3.zero;
                    prefab.transform.position += _lastCoordinate;
                    prefab.SetActive(true);
                    
                    break;
                }
            }
        }
        else
        {
            foreach (var prefab in pool)
            {
                if (!prefab.activeInHierarchy)
                {
                    _lastCoordinate += forwardSide;
                    prefab.transform.position = Vector3.zero;
                    prefab.transform.position += _lastCoordinate;
                    prefab.SetActive(true);
                    
                    break;
                }
            }
        }

        
    }


    IEnumerator SetPlatform()
    {
        while (isAlive)
        {
            yield return new WaitForSeconds(.2f);
            GetPlatformFromPool();
        }
    }

}
