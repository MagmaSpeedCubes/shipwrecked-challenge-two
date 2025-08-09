using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{

    public bool locked;
    public bool prevLocked;

    public Sprite doorUnlockedIcon;
    public Sprite doorLockedIcon;

    SpriteRenderer sr;

    Collider2D col;

    public GameObject icon;

    public Color32 lockedColor = new Color32(200, 69, 36, 255);
    public Color32 unlockedColor = new Color32(123, 69, 36, 126);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = gameObject.GetComponent<Collider2D>();


        sr = gameObject.GetComponentInChildren<SpriteRenderer>();

        if (locked)
            {
                sr.color = lockedColor;
                icon.GetComponent<SpriteRenderer>().sprite = doorLockedIcon;
                col.isTrigger = false;
            }

            else if (!locked)
            {
                sr.color = unlockedColor;
                icon.GetComponent<SpriteRenderer>().sprite = doorUnlockedIcon;
                col.isTrigger = true;
            }

    }

    // Update is called once per frame
    void Update()
    {
        if (prevLocked != locked)
        {
            if (locked)
            {
                sr.color = lockedColor;
                icon.GetComponent<SpriteRenderer>().sprite = doorLockedIcon;
                col.isTrigger = false;
            }

            else if (!locked)
            {
                sr.color = unlockedColor;
                icon.GetComponent<SpriteRenderer>().sprite = doorUnlockedIcon;
                col.isTrigger = true;
            }

            prevLocked = locked;

        }

        prevLocked = locked;

        
    }

    public void ForceUpdate()
    {
        if (prevLocked != locked)
        {
            if (locked)
            {
                sr.color = lockedColor;
                icon.GetComponent<SpriteRenderer>().sprite = doorLockedIcon;
                col.isTrigger = false;
            }

            else if (!locked)
            {
                sr.color = unlockedColor;
                icon.GetComponent<SpriteRenderer>().sprite = doorUnlockedIcon;
                col.isTrigger = true;
            }

            prevLocked = locked;

        }

        prevLocked = locked;

    }

}
