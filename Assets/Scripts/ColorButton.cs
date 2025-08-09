using UnityEngine;
using UnityEngine.UI;
public class ColorButton : MonoBehaviour
{
    [SerializeField] private int colorIndex;

    void Start()
    {
        GetComponent<Image>().color = GameManager.instance.colors[colorIndex];
    }

    public void OnClick()
    {

        for(int i=0; i < GuessManager.instance.guessSequence.Length; i++)
        {
            Debug.Log("checking index: " + i);
            if (GuessManager.instance.guessSequence[i] == -1)
            {
                Debug.Log("found empty slot at index: " + i);
                GuessManager.instance.guessSequence[i] = colorIndex;
                GuessManager.instance.UpdateCurrentGuess();
                return;
            }
        }

    }
    
}
