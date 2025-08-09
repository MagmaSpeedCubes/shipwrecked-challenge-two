using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public Color[] colors;

    private int maxGuesses = 10;
    public int currentGuessCount = 0;

    private int[] correctSequence;

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

    public int[] Guess(int[] guessSequence)
    {
        int[] output = new int[guessSequence.Length];

        for (int i = 0; i < guessSequence.Length; i++)
        {
            if (guessSequence[i] == correctSequence[i])
            {
                output[i] = 2; //Correct color
                correctSequence[i] = -1; //mark as used

            }
            else if (System.Array.IndexOf(correctSequence, guessSequence[i]) != -1)
            {
                output[i] = 1; //Wrong position
                correctSequence[System.Array.IndexOf(correctSequence, guessSequence[i])] = -1; //mark as used

            }
            else
            {
                output[i] = 0; //Wrong color
            }

        }
        return output;
    }

    public void EndGame(bool win)
    {
        
    }



    
}
