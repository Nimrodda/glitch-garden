using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour 
{
    private Vector2 pos = new Vector2();
    private GameObject defendersParent;
    private GameGrid gameGrid = new GameGrid(9, 5);
    // Use this for initialization
    void Start () 
    {
        defendersParent = new GameObject("Defenders");
        
    }
    
    // Update is called once per frame
    void Update () 
    {
        
    }

    void OnMouseDown()
    {
        if (DefenderPicker.Selected)
        {
            pos.x = Input.mousePosition.x;
            pos.y = Input.mousePosition.y;
            Vector2 worldpos = Camera.main.ScreenToWorldPoint(pos);
            worldpos.x = Mathf.Clamp(Mathf.Round(worldpos.x), 1f, 9f);
            worldpos.y = Mathf.Clamp(Mathf.Round(worldpos.y), 1f, 5f);

            int x = (int)worldpos.x - 1;
            int y = (int)worldpos.y - 1;

            if (gameGrid.Update(x, y))
            {
                print("Instantiating " + DefenderPicker.Selected.name + " in grid " + worldpos);
                var defender = Instantiate(DefenderPicker.Selected, worldpos, Quaternion.identity);
                defender.transform.parent = defendersParent.transform;
            }
            else
            {
                print("Defender already exists at " + worldpos);
            }
            print(gameGrid.toString());
        }
    }
}
