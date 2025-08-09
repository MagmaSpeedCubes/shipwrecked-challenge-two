using UnityEngine;
using UnityEngine.UI;

public class DoorListenerScript : MonoBehaviour
{
    public Button startMinigameButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startMinigameButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            startMinigameButton.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            startMinigameButton.gameObject.SetActive(false);
        }
    }
}
