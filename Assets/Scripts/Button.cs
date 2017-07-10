using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour 
{
    public delegate void OnClickEventHandler(GameObject button);
    public event OnClickEventHandler OnClick;

    void OnMouseDown()
    {
        OnClick(gameObject);
    }
}
