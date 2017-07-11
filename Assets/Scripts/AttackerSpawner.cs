using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour 
{
    public float spawnDelaySeconds;
    public GameObject attackerPrefab;

    private Timer timer;

    void Start () 
    {
        timer = GetComponent<Timer>();
        if (timer)
        {
            timer.Finish += () => {
                print("Finish()");
                InvokeRepeating("ShouldSpawnAttacker", spawnDelaySeconds, spawnDelaySeconds);
            };
            timer.Run();
        }
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
