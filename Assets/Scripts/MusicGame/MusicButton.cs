using UnityEngine;
using UnityEngine.UI;
public class MusicButton : MonoBehaviour
{
    [SerializeField] private int id;

    void Start()
    {
        Debug.Log("Start");
    }

    public void OnClick()
    {
        // Game.instance.setGuess(id);
        playSound();
    }

    public void playSound()
    {
        //play sound
        Debug.Log("Sound" + id);
    }
    
}
