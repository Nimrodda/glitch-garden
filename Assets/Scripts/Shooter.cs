using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour 
{
    public GameObject projectile;
    private GameObject parent;
    private Vector3 gunPosition;

    // Use this for initialization
    void Start () 
    {
        parent = GameObject.Find("Projectiles");
        if (!parent)
        {
            parent = new GameObject("Projectiles");
        }
        gunPosition = transform.Find("Gun").transform.position;
    }
    
    // Update is called once per frame
    void Update () 
    {
        
    }

    private void fire()
    {
        print("fire() was called");
        GameObject newProjectile = Instantiate(projectile, gunPosition, Quaternion.identity) as GameObject;
        newProjectile.transform.parent = parent.transform;

    }
}
