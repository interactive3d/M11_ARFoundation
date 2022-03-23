using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject prefab;

    public void ChangePrefab(GameObject newPrefab)
    {
        prefab = newPrefab;
    }

    public void InstantiatePrefab()
    {
        Instantiate(prefab, transform);
    }
}
