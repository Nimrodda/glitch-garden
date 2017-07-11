using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour 
{
    private Vector2 pos = new Vector2();
    private GameObject defendersParent;
    private StarDisplay starDisplay;
    private DefenderSpawnerController controller;

    void Start() 
    {
        controller = new DefenderSpawnerController(this);
        defendersParent = new GameObject("Defenders");
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }
    
    void OnMouseDown()
    {
        if (!DefenderPicker.Selected)
        {
            print("No defender selected");
            return;
        }
        Vector2 gridPos = getGridPosition();
        controller.OnGridClicked(gridPos.x, gridPos.y);
    }

    private Vector2 getGridPosition()
    {
        pos.x = Input.mousePosition.x;
        pos.y = Input.mousePosition.y;
        Vector2 worldpos = Camera.main.ScreenToWorldPoint(pos);
        worldpos.x = Mathf.Clamp(Mathf.Round(worldpos.x), 1f, 9f);
        worldpos.y = Mathf.Clamp(Mathf.Round(worldpos.y), 1f, 5f);
        return worldpos;
    }

    public bool HasSufficientFunds()
    {
        var selectedDefender = DefenderPicker.Selected.GetComponent<Defender>();
        return selectedDefender.Cost <= starDisplay.Stars;
    }

    public void SpawnDefenderAtPosition(float x, float y)
    {
        var newDefender = Instantiate(DefenderPicker.Selected, new Vector2(x, y), Quaternion.identity);
        newDefender.transform.parent = defendersParent.transform;
    }

    public void UpdateFunds()
    {
        var selectedDefender = DefenderPicker.Selected.GetComponent<Defender>();
        starDisplay.RemoveStars(selectedDefender.Cost);
    }
}
