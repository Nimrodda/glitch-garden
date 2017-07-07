using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(-1f, 1.5f)]
    public float walkSpeed;
    // Use this for initialization
    void Start ()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
    }

    public void SetSpeed(float speed)
    {
        walkSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        print(name + 
            " striking target");
    }
}
