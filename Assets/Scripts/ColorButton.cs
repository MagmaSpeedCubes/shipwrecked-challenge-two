using UnityEngine;
using UnityEngine.UI;
public class ColorButton : MonoBehaviour
{
    [SerializeField] private int colorIndex;

    void Start()
    {
        GetComponent<Image>().color = GameManager.instance.colors[colorIndex];
    }

    void OnClick()
    {
        if (GuessManager.instance.guessSequence[GuessManager.instance.guessSequence.Length] != -1)
        //the last item in the guess sequence is empty
        {
            GuessManager.instance.guessSequence[GuessManager.instance.guessSequence.Length] = colorIndex;
            GuessManager.instance.UpdateCurrentGuess();
        }
        else
        {
            //play error sound here
            //guess sequence is full
        }
    }
    
}
