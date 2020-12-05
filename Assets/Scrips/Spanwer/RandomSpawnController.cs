using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnController : MonoBehaviour
{
    [Range(0, 10)] public float _obsVelocity;
    public List<GameObject> _obs;

    private void Start()
    {
        InvokeRepeating("Instance", 2, 1);
    }
    void Instance()
    {
        Instantiate(_obs[Random.Range(0, _obs.Count)], transform.GetChild(0));
    }
}