using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _platformPrefabs;
    private float zOffset;
    private GameObject tempGO;
    private GameObject lastPlatform; // viimeinen platform

    void Start()
    {
        Shuffle();

        float totalSize = 0f;
        GameObject[] instantiatedPlatforms = new GameObject[_platformPrefabs.Length];

        for (int i = 0; i < _platformPrefabs.Length; i++)
        {
            float prefabSize = GetPrefabSize(_platformPrefabs[i]);
            instantiatedPlatforms[i] = Instantiate(_platformPrefabs[i], new Vector3(0, 0, totalSize), Quaternion.identity);
            totalSize += prefabSize;
            totalSize += 40.0f; // platformin z koko
        }

        zOffset = totalSize; 
        lastPlatform = instantiatedPlatforms[instantiatedPlatforms.Length - 1]; 
    }

    public void RecyclePlatform(GameObject platform)
    {
        float prefabSize = GetPrefabSize(platform);
        platform.transform.position = lastPlatform.transform.position + Vector3.forward * prefabSize;
        zOffset += prefabSize;

        lastPlatform = platform; 
    }

    private float GetPrefabSize(GameObject prefab)
    {
        Collider collider = prefab.GetComponentInChildren<Collider>();
        if (collider != null)
        {
            return collider.bounds.size.z;
        }
        else
        {
            Debug.LogError("ERROR");
            return 0f;
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i < _platformPrefabs.Length; i++)
        {
            int rnd = Random.Range(0, _platformPrefabs.Length);
            tempGO = _platformPrefabs[rnd];
            _platformPrefabs[rnd] = _platformPrefabs[i];
            _platformPrefabs[i] = tempGO;
        }
    }
}