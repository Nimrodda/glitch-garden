using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour 
{
    public int value;
    private Animator animator;
    private StarDisplay starDisplay;
    
    void Start()
    {
        animator = transform.parent.transform.parent.GetComponent<Animator>();
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    void OnMouseDown()
    {
        starDisplay.AddStars(value);
        animator.SetTrigger("Picked");
    }
}
