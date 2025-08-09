using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorListenerScript : MonoBehaviour
{
    public TMPro_Button startMinigameButton;

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
        if (col.gameObject.tag == "player")
        {
            startMinigameButton.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "player")
        {
            startMinigameButton.gameObject.SetActive(false);
        }
    }
}
