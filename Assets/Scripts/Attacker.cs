using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(-1f, 1.5f)]
    public float walkSpeed;

    private Animator animator;
    private GameObject currentTarget;
    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void SetSpeed(float speed)
    {
        walkSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.Damage(damage);
            }
        }
    }

    public void attack(GameObject defender)
    {
        currentTarget = defender;
    }
}
