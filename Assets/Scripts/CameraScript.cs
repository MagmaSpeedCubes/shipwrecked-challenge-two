using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject player;

    Vector3 targetpos;

    float speed = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("CameraX") && PlayerPrefs.HasKey("CameraY"))
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("CameraX"), PlayerPrefs.GetFloat("CameraY"), -10);
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        targetpos = player.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, targetpos, step);

        transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        PlayerPrefs.SetFloat("CameraX", transform.position.x);
        PlayerPrefs.SetFloat("CameraY", transform.position.y);
    }
}
