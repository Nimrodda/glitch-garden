using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour 
{
    public float spawnDelaySeconds;
    public GameObject attackerPrefab;

    void Start () 
    {
        InvokeRepeating("ShouldSpawnAttacker", spawnDelaySeconds, spawnDelaySeconds);
    }
    
    void ShouldSpawnAttacker()
    {
        if (Random.value > 0.8f)
        {
            var attacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity);
            attacker.transform.parent = transform;
        }
    }
}
