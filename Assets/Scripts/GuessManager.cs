using UnityEngine;

public class GuessManager : MonoBehaviour
{
    public static GuessManager instance { get; private set; }

    public int[] guessSequence;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("Multiple instances of GameManager detected. Destroying the new instance.");
            Destroy(gameObject);
        }
    }

    public void OnClick()
    {
        if (guessSequence[guessSequence.Length] != -1)
        {
            GameManager.instance.currentGuessCount++;

            int[] result = GameManager.instance.Guess(guessSequence);

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == 2)
                {
                    //correct color
                }
                else if (result[i] == 1)
                {
                    //wrong position
                }
                else
                {
                    //wrong color
                }
            }


            for (int i = 0; i < guessSequence.Length; i++)
            {
                guessSequence[i] = -1;
                //reset guess sequence
            }


        }
    }

    public void UpdateCurrentGuess()
    {

    }

    public void DeleteLastGuess()
    {
        for (int i = guessSequence.Length - 1; i >= 0; i--)
        {
            if (guessSequence[i] != -1)
            {
                guessSequence[i] = -1;
                break;
            }
        }
    }

    
}
