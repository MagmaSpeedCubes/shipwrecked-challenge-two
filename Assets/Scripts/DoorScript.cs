using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{

    public bool locked;
    public bool prevLocked;

    public Sprite doorUnlockedIcon;
    public Sprite doorLockedIcon;

    SpriteRenderer sr;

    SpriteRenderer iconSR;

    public Color32 lockedColor = new Color32(200, 69, 36, 255);
    public Color32 unlockedColor = new Color32(123, 69, 36, 255);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = gameObject.GetComponentInChildren<SpriteRenderer>();

        iconSR = UnityEngine.GameObject.Find("Door/Icon").GetComponentInChildren<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        if (prevLocked != locked)
        {
            if (locked)
            {
                sr.color = lockedColor;
            }

            else if (!locked)
            {
                sr.color = unlockedColor;
            }

            prevLocked = locked;

        }

        prevLocked = locked;

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print("hello 1");
        if (locked == false)
        {
            print("hello 2");
            if (col.gameObject.CompareTag("Player") == true)
            {
                print("hello 3");
                var scene = SceneManager.GetActiveScene();
                int index = scene.buildIndex;
                SceneManager.LoadScene(index+1);
            }
        }

    }
}
