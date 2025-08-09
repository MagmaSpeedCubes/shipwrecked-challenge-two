using UnityEngine;

public class SpinnerManager : MonoBehaviour
{
    public static SpinnerManager instance { get; private set; }

    public Color[] segmentColors;
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
    

}
