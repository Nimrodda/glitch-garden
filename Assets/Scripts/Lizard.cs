using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour {
    private Attacker attacker;
    private Animator animator;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject defender = other.gameObject;
        if (defender.GetComponent<Defender>())
        {
            animator.SetBool("isAttacking", true);
            attacker.attack(defender);
        }
    
    }
}
