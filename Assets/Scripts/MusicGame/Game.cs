using UnityEngine;
using UnityEngine.UI;
public class Game : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    private int[] CorrectSequence = new int[4];

    private int[] Sequence = { 0, 1, 2, 3, 4, 5, 6 };
    private int[] startSequence = { 0, 1, 2, 3, 4, 5, 6 };

    private string Stage = "intro";

    private int[] guessSequence = new int[4];

    private int playIndex = 0;
    private int guessed = 0;
    private int guess = -1;

    private bool won = true;

    public Button[] buttons;

    void Start()
    {
        GenerateSequence();
        for (int i = 0; i < CorrectSequence.Length; i++)
        {
            Debug.Log("Correct" + CorrectSequence[i]);
        }
    }

    void Update()
    {
        // INTRO
        // play notes sequentially
        if (Stage == "intro")
        {
            playSequence(startSequence);
            if (playIndex >= startSequence.Length)
            {
                Stage = "sequence";
                won = false;
                playIndex = 0;
            }
        }

        // GAME
        // loop until correct
        if (!won)
        {
            // SEQUENCE 
            // play correct sequence
            if (Stage == "sequence")
            {
                playSequence(CorrectSequence);
                if (playIndex >= CorrectSequence.Length)
                {
                    Stage = "guess";
                    playIndex = 0;
                }
            }

            // GUESS
            // loop until guessed all spots
            if ((guessed < CorrectSequence.Length) && (guess != -1))
            {
                // add button clicks to array
                Debug.Log(guess);
                guessSequence[guessed] = guess;
                guessed++;
                guess = -1;
            }

            // CHECK
            // check if guess sequence is correct

            // RESULTS
            // handle result
        }

    }

    void GenerateSequence()
    {
        int size = Sequence.Length;
        int count = 0;
        while (count < 4)
        {
            int i = Random.Range(0, size);
            while (Sequence[i] == -1)
            {
                i++;
            }

            Sequence[i] = -1;

            CorrectSequence[count] = i;

            count++;
            size--;
        }
    }

    bool CheckGuess()
    {
        for (int i = 0; i < CorrectSequence.Length; i++)
        {
            if (CorrectSequence[i] != guessSequence[i])
            {
                return false;
            }
        }
        return true;
    }

    void playSequence(int[] seq)
    {
        playNote(seq, playIndex);
        playIndex++;
    }

    void playNote(int[] sequence, int i)
    {
        buttons[sequence[i]].GetComponent<MusicButton>().playSound();
    }

    public void setGuess(int g)
    {
        guess = g;
    }
}
