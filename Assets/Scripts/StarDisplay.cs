using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

    public int initialStars;
    public int Stars { get; private set; }
    private Text display;

    void Start () {
        Stars = initialStars;
        display = GetComponent<Text>();
        display.text = Stars.ToString();
    }
    
    public void AddStars(int amount)
    {
        Stars += amount;
        display.text = Stars.ToString();
    }

    public void RemoveStars(int amount)
    {
        Stars -= amount;
        display.text = Stars.ToString();
    }
}
