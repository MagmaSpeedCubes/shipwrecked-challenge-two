using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class Game : MonoBehaviour
{
    public static Game instance { get; private set; }

    private int[] CorrectSequence = new int[4];

    private int[] Sequence = { 0, 1, 2, 3, 4, 5, 6 };

    private readonly int[] startSequence = { 0, 1, 2, 3, 4, 5, 6 };

    private string Stage = "sequence";

    private int[] guessSequence = new int[4];

    private int playIndex = 0;
    private int guessed = 0;
    private int guess = -1;

    private float timer = 0;

    private bool won = false;

    public Button[] buttons;

    void Start()
    {
        GenerateSequence();
    }

    void Update()
    {
        // INTRO
        // play notes sequentially
        if (Stage == "intro")
        {
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                timer = 0;
                playSequence(startSequence);
                if (playIndex >= startSequence.Length)
                {
                    Stage = "sequence";
                    won = false;
                    playIndex = 0;
                }
            }
        }

        // GAME
        // loop until correct
        else if (!won)
        {
            // SEQUENCE 
            // play correct sequence
            if (Stage == "sequence")
            {
                timer += Time.deltaTime;
                if (timer > 0.5f)
                {
                    timer = 0;
                    playSequence(CorrectSequence);
                    if (playIndex >= CorrectSequence.Length)
                    {
                        Stage = "guess";
                        playIndex = 0;
                    }
                }
            }

            // GUESS
            // loop until guessed all spots
            if (Stage == "guess" && (guess != -1))
            {
                // add button clicks to array
                guessSequence[guessed] = guess;
                guessed++;
                guess = -1;
                Debug.Log("GUESS" + guessed);

                if (guessed >= CorrectSequence.Length)
                {
                    Stage = "check";
                    guessed = 0;
                }
            }

            // CHECK
            // check if guess sequence is correct
            if (Stage == "check")
            {
                won = CheckGuess();
                if (!won)
                {
                    guessSequence = new int[4];
                    Stage = "sequence";
                    Thread.Sleep(1000);
                }
            }

            // RESULTS
            // handle result
        }

        else
        {
            Advance();
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

    void showSequence() {
        for (int i = 0; i < CorrectSequence.Length; i++)
        {
            Debug.Log("Correct" + CorrectSequence[i]);
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

    void Advance()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
    }
}
