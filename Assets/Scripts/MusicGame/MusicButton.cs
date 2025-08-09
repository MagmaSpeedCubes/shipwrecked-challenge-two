using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;
public class MusicButton : MonoBehaviour
{
    [SerializeField] private int id;

    GameObject MusicManagerObject;

    Game GameScript;

    void Start()
    {
        MusicManagerObject = GameObject.Find("MusicManager");
        GameScript = MusicManagerObject.GetComponent<Game>();
    }

    public void OnClick()
    {
        GameScript.setGuess(id);
        playSound(new Color(0.5f, 0.5f, 0.5f, 1f));
    }

    public void playSound(Color color)
    {
        //play sound
        StartCoroutine(ChangeColorRoutine(color));
    }

    private IEnumerator ChangeColorRoutine(Color color)
    {
        // Change to gray
        GetComponent<Image>().color = color;

        // Wait for 1 second without freezing Unity
        yield return new WaitForSeconds(0.5f);

        // Change back to white
        GetComponent<Image>().color = Color.white;

        Debug.Log("sound " + id);

    }
    
}
