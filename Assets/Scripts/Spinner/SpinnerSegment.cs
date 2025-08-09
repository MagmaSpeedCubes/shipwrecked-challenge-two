using UnityEngine;
using UnityEngine.UI;
public class SpinnerSegment : MonoBehaviour
{
    [SerializeField] private int segmentIndex;
    void Awake()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Image>().color = SpinnerManager.instance.segmentColors[segmentIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
