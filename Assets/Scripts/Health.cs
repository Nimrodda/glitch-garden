using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour 
{
    public GameObject healthbarPrefab;
    public float health;

    private RectTransform healthbar;
    private float healthbarWidth;
    private float initialHealth;

    void Start () 
    {
        var hb = Instantiate(healthbarPrefab, transform.position, Quaternion.identity);
        hb.GetComponent<RectTransform>().SetParent(transform);
        healthbar = hb.transform.Find("Bar").GetComponent<RectTransform>();
        healthbarWidth = healthbar.sizeDelta.x;	
        initialHealth = health;
    }
    
    public void Damage(float hit)
    {
        health -= hit;
        updateHealthbar();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void updateHealthbar()
    {
        float y = healthbar.sizeDelta.y;
        healthbar.sizeDelta = new Vector2(healthbarWidth / initialHealth * health, y);
    }
}
