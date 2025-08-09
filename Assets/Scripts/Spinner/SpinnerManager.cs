using UnityEngine;

public class SpinnerManager : MonoBehaviour
{
    public static SpinnerManager instance { get; private set; }
    public GameObject[] spinners;
    [SerializeField] private float[] spinnerSpeed;
    public int activeSpinner = 0;

    public int[] hitColorIndices;

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

    void Start()
    {
        GenerateHitColors();
    }

    void Update()
    {

        spinners[activeSpinner].transform.Rotate(0, 0, spinnerSpeed[activeSpinner] * Time.deltaTime * 360f);

    }

    public void GenerateHitColors()
    {
        hitColorIndices = new int[3];
        for (int i = 0; i < 3; i++)
        {
            hitColorIndices[i] = Random.Range(0, segmentColors.Length);
        }
    }

    public void Hit(int hitColorIndex)
    {
        if (hitColorIndex == hitColorIndices[activeSpinner])
        {
            if (activeSpinner == spinners.Length - 1)
            {
                activeSpinner = -1;
                Advance();
            }
            else
            {
                activeSpinner++;

            }
        }
        else
        {
            for (int i = 0; i < spinners.Length; i++)
            {
                if (i != activeSpinner)
                {
                    spinners[i].transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                activeSpinner = 0;
            }
            
        }
    }

    public void Advance() {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
    }

}
