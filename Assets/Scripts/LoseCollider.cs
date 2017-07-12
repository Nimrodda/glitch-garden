using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseCollider : MonoBehaviour 
{
    private bool lost;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Attacker>())
        {
            if (!lost)
            {
                lost = true;
                transform.Find("Lose Text").GetComponent<Text>().enabled = true;
                Time.timeScale = 0;
            }
        }
    }
}
