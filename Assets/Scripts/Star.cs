using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour 
{
    public int value;
    private Animator animator;
    void Start()
    {
        animator = transform.parent.transform.parent.GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        // TODO: Add up to total stars
        animator.SetTrigger("Picked");
    }
}
