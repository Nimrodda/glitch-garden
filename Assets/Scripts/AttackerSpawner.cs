using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {
    public float spawnDelaySeconds;
    public GameObject attackerPrefab;
    private GameObject attackersParent;
    // Use this for initialization
    void Start () {
        attackersParent = new GameObject("Attackers");
        InvokeRepeating("ShouldSpawnAttacker", spawnDelaySeconds, spawnDelaySeconds);
    }
    
    void ShouldSpawnAttacker()
    {
        if (Random.value > 0.8f)
        {
            var attacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity);
            attacker.transform.parent = attackersParent.transform;
        }
    }
    // Update is called once per frame
    void Update () {
        
    }
}
