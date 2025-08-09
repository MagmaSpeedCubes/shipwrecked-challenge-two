using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject player;

    Vector3 targetpos;

    float speed = 4.6f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        targetpos = player.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, targetpos, step);
        
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
