using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderPicker : MonoBehaviour 
{
    public GameObject[] defenderPrefab;
    public GameObject costPrefab;

    public static GameObject Selected { get; set; }
    
    private Dictionary<GameObject, GameObject> buttonPrefabMapping = new Dictionary<GameObject, GameObject>();
    
    // Use this for initialization
    void Start () 
    {
        float x;
        if (defenderPrefab.Length % 2 == 0)
        {
            x = (float)defenderPrefab.Length / 2f + 0.5f; 
        }
        else
        {
            x = (float)((defenderPrefab.Length + 1) / 2);
        }
        var background = transform.Find("Background");
        background.transform.localScale = new Vector3((float)defenderPrefab.Length, 1f, 0f);
        background.transform.position = new Vector3(x, 6f, 0f);
        createButtons();
    }
    
    private void createButtons()
    {
        Vector3 buttonPos = new Vector3(1f, 6f, 0f);
        Vector2 colliderSize = new Vector2(1f, 1.1f);
        Vector3 scale = new Vector3(0.75f, 0.75f, 1f);

        foreach (GameObject prefab in defenderPrefab)
        {
            GameObject button = new GameObject("Button");
            button.name = prefab.name + " Button";
            button.transform.parent = transform;
            button.transform.localScale = scale;
            button.transform.position = buttonPos;
            button.AddComponent<Button>().OnClick += OnClick;
            var spriteRenderer = button.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = prefab.transform.Find("Body").GetComponent<SpriteRenderer>().sprite;
            spriteRenderer.color = Color.black;
            var collider = button.AddComponent<BoxCollider2D>();
            var cost = Instantiate(costPrefab, button.transform.position, Quaternion.identity);
            cost.GetComponent<RectTransform>().SetParent(button.transform);
            cost.transform.Find("Text").GetComponent<Text>().text = prefab.GetComponent<Defender>().Cost.ToString();
            collider.isTrigger = true;
            collider.size = colliderSize;

            buttonPrefabMapping[button] = prefab;
            buttonPos += Vector3.right;
        }
    }
    void OnClick(GameObject button)
    {
        Selected = buttonPrefabMapping[button];
        button.GetComponent<SpriteRenderer>().color = Color.white;
        foreach (var b in buttonPrefabMapping.Keys)
        {
            if (b != button)
            {
                b.GetComponent<SpriteRenderer>().color = Color.black;
            }
        }
    }

    // Update is called once per frame
    void Update () 
    {
        
    }
}
