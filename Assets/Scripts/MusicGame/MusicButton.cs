using UnityEngine;
using UnityEngine.UI;
public class MusicButton : MonoBehaviour
{
    [SerializeField] private int id;

    GameObject MusicManagerObject;

    Game GameScript;

    void Start()
    {
        Debug.Log("Start");
        MusicManagerObject = GameObject.Find("MusicManager");
        GameScript = MusicManagerObject.GetComponent<Game>();
    }

    public void OnClick()
    {
        GameScript.setGuess(id);
        playSound();
    }

    public void playSound()
    {
        //play sound
        // Debug.Log("Sound" + id);
    }
    
}
