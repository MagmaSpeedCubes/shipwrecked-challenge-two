using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class GuessManager : MonoBehaviour
{
    public static GuessManager instance { get; private set; }

    public int[] guessSequence;
    public GameObject guessPrefab;
    public GameObject[] guessObjects;
    public GameObject[] infoIndicatorObjects;

    public List<GameObject> previousGameObjects = new List<GameObject>();

    public Sprite[] infoIndicators;


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

    void Start()
    {
        StartGame();
    }


    public void OnClick()
    {
        if (GameManager.instance.currentGuessCount < GameManager.instance.maxGuesses)
        {
            Debug.Log(GameManager.instance.currentGuessCount + " < " + GameManager.instance.maxGuesses);


            if (guessSequence[guessSequence.Length - 1] != -1)
            {
                GameManager.instance.currentGuessCount++;

                int[] result = GameManager.instance.Guess(guessSequence);

                for (int i = 0; i < result.Length; i++)
                {
                    infoIndicatorObjects[i].GetComponent<Image>().sprite = infoIndicators[result[i]]; //wrong position
                }

                if (GameManager.instance.currentGuessCount < GameManager.instance.maxGuesses)
                {
                    SetupNextGuess();  
                }
                



            }
        }
    }

    public void SetupNextGuess()
    {


        guessObjects = new GameObject[GameManager.instance.correctSequence.Length];
        infoIndicatorObjects = new GameObject[GameManager.instance.correctSequence.Length];

        float spacing = 100f; // distance between objects
        int count = guessObjects.Length;
        float totalWidth = (count - 1) * spacing;
        float startX = -totalWidth / 2f;
        float startY = -GameManager.instance.currentGuessCount * 100f + 300; // Adjust Y position based on current guess count

        for (int i = 0; i < count; i++)
        {
            guessObjects[i] = Instantiate(guessPrefab, transform);
            guessObjects[i].GetComponent<Image>().color = new Color(0, 0, 0, 0); //transparent

            infoIndicatorObjects[i] = Instantiate(guessPrefab, transform);
            infoIndicatorObjects[i].GetComponent<Image>().sprite = infoIndicators[0]; // default sprite

            // Centered position calculation
            guessObjects[i].GetComponent<RectTransform>().localScale = Vector3.one * 0.8f;
            infoIndicatorObjects[i].GetComponent<RectTransform>().localScale = Vector3.one * 0.8f;


            float x = startX + i * spacing;
            float y = startY;
            guessObjects[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            infoIndicatorObjects[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
        }

        guessSequence = new int[GameManager.instance.correctSequence.Length];
        for (int i = 0; i < guessSequence.Length; i++)
        {
            Debug.Log("resetting guess sequence");
            guessSequence[i] = -1;
            //reset guess sequence
        }

        for (int i = 0; i < guessObjects.Length; i++)
        {
            previousGameObjects.Add(guessObjects[i]);
            previousGameObjects.Add(infoIndicatorObjects[i]);
        }
    }


    public void StartGame()
    {
        GameManager.instance.currentGuessCount = 0;
        for (int i = 0; i < previousGameObjects.Count; i++)
        {
            Destroy(previousGameObjects[i]);
        }
        previousGameObjects.Clear();
        GameManager.instance.GenerateNewSequence();
        SetupNextGuess();    
        Debug.Log("Game started with new sequence: " + string.Join(", ", GameManager.instance.correctSequence));
    }

    public void UpdateCurrentGuess()
    {
        for (int i = 0; i < guessSequence.Length; i++)
        {
            if (guessSequence[i] != -1)
            {
                guessObjects[i].GetComponent<Image>().color = GameManager.instance.colors[guessSequence[i]];
                Debug.Log("color");
            }
            else
            {
                guessObjects[i].GetComponent<Image>().color = new Color(0, 0, 0, 0); //transparent
            }
        }
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

        UpdateCurrentGuess();
    }

    
}
