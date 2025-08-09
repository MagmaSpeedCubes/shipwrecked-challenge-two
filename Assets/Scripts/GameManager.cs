using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public Color[] colors;

    public int maxGuesses = 5;
    public int currentGuessCount = 0;

    public int[] correctSequence;

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
    int[] correctSequenceCopy = (int[])correctSequence.Clone(); // Deep copy

        /*

        for (int i = 0; i < guessSequence.Length; i++)
            {
                if (guessSequence[i] == correctSequenceCopy[i])
                {
                    output[i] = 3; // Correct color
                    correctSequenceCopy[i] = -1; // mark as used
                }
                else if (System.Array.IndexOf(correctSequenceCopy, guessSequence[i]) != -1)
                {
                    output[i] = 2; // Wrong position
                    correctSequenceCopy[System.Array.IndexOf(correctSequenceCopy, guessSequence[i])] = -1; // mark as used
                }
                else
                {
                    output[i] = 1; // Wrong color
                }
            }

        */

    int[] guessSequenceCopy = (int[])guessSequence.Clone(); // Deep copy

    for (int i = 0; i < correctSequence.Length; i++)
    {
            if (correctSequenceCopy[i] == guessSequenceCopy[i])
            {
                output[i] = 3; // Correct color
                correctSequenceCopy[i] = -1; // mark as used
                guessSequenceCopy[i] = -1;
        }
        
    }

    for (int i = 0; i < guessSequenceCopy.Length; i++)
    {
        if (guessSequenceCopy[i] == -1) continue; // Skip already matched colors
        if (System.Array.IndexOf(correctSequenceCopy, guessSequenceCopy[i]) != -1)
            {
                output[i] = 2; // Wrong position
                correctSequenceCopy[System.Array.IndexOf(correctSequenceCopy, guessSequenceCopy[i])] = -1; // mark as used
            }
            else
            {
                output[i] = 1; // Wrong color
            }
    }

    return output;
}

    
    public void EndGame(bool win)
    {

    }
    public void GenerateNewSequence()
    {
        correctSequence = new int[5];

        for (int i = 0; i < correctSequence.Length; i++)
        {

            correctSequence[i] = Random.Range(0, colors.Length);
        }
        Debug.Log("New sequence generated: " + string.Join(", ", correctSequence));
    }



    
}
