using UnityEngine;
using UnityEngine.UI;
public class SpinnerButton : MonoBehaviour
{
    [SerializeField] private int buttonIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentAngle = SpinnerManager.instance.spinners[SpinnerManager.instance.activeSpinner].transform.eulerAngles.z;
        int spinnerRegion = (int)(((currentAngle + 90) %360)/360 * -8 + 8);
        //+270 to adjust the angle so that 0 is at the side
        // %360 to keep the angle within 0-360 degrees
        // *-8 to convert to a range of 0-8 for the spinner segments
        // +8 to avoid negative indices
        GetComponent<Image>().color = SpinnerManager.instance.segmentColors[spinnerRegion];
    }
}
