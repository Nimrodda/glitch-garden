using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour 
{
    private Vector2 pos = new Vector2();
    private GameObject defendersParent;
    private const int GRID_ROWS = 5;
    private const int GRID_COL = 9;
    private int[][] grid = new int[GRID_COL][];

    // Use this for initialization
    void Start () 
    {
        for (int i = 0; i < GRID_COL; i++)
        {
            grid[i] = new int[GRID_ROWS];
        }
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

            int x = (int)worldpos.x;
            int y = (int)worldpos.y;

            if (grid[x][y] == 0)
            {
                print("Instantiating " + DefenderPicker.Selected.name + " in grid " + worldpos);
                var defender = Instantiate(DefenderPicker.Selected, worldpos, Quaternion.identity);
                defender.transform.parent = defendersParent.transform;
                grid[(int)worldpos.x - 1][(int)worldpos.y - 1] = 1;
            }
            else
            {
                print("Defender already exists at " + worldpos);
            }
        }
    }
}
