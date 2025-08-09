using UnityEngine;

public class SpinnerManager : MonoBehaviour
{
    public static SpinnerManager instance { get; private set; }
    public GameObject[] spinners;
    [SerializeField] private float[] spinnerSpeed;
    public int activeSpinner = 0;

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

    void Update()
    {

        spinners[activeSpinner].transform.Rotate(0, 0, spinnerSpeed[activeSpinner] * Time.deltaTime * 360f);

    }
    

}
