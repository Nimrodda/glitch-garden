using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour 
{
    public AudioClip projectileSound;
    public GameObject projectile;
    private GameObject parent;
    private Vector3 gunPosition;
    private GameObject attackerSpawner;
    private Animator animator;

    // Use this for initialization
    void Start () 
    {
        parent = GameObject.Find("Projectiles");
        attackerSpawner = GameObject.Find("Spawner" + transform.position.y);
        animator = GetComponent<Animator>();
        if (!parent)
        {
            parent = new GameObject("Projectiles");
        }
        gunPosition = transform.Find("Gun").transform.position;
    }
    
    // Update is called once per frame
    void Update () 
    {
        if (isAttackerAhead())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool isAttackerAhead()
    {
        if (attackerSpawner.transform.childCount > 0)
        {
            foreach (Transform attacker in attackerSpawner.transform)
            {
                if (transform.position.x < attacker.position.x)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void fire()
    {
        AudioSource.PlayClipAtPoint(projectileSound, transform.position);
        GameObject newProjectile = Instantiate(projectile, gunPosition, Quaternion.identity) as GameObject;
        newProjectile.transform.parent = parent.transform;

    }
}
