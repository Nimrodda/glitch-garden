using UnityEngine;

public class Defender : MonoBehaviour
{
    Vector3 pos = new Vector3();

    void Start ()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }

    void OnMouseDrag()
    {
        pos.x = Input.mousePosition.x;
        pos.y = Input.mousePosition.y;
        pos.z = Input.mousePosition.z;
        Vector3 worldpos = Camera.main.ScreenToWorldPoint(pos);
        worldpos.x = Mathf.Clamp(Mathf.Round(worldpos.x), 1f, 9f);
        worldpos.y = Mathf.Clamp(Mathf.Round(worldpos.y), 1f, 5f);
        worldpos.z = 0;
        print(worldpos);
        gameObject.transform.position = worldpos;
    }
}
