using UnityEngine;
using UnityEngine.UI;
public class SpinnerButton : MonoBehaviour
{
    [SerializeField] private int buttonIndex;
    int spinnerRegion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float currentAngle = SpinnerManager.instance.spinners[buttonIndex].transform.eulerAngles.z;
        spinnerRegion = (int)(((currentAngle + 90) % 360) / 360 * -8 + 8);
        //+270 to adjust the angle so that 0 is at the side
        // %360 to keep the angle within 0-360 degrees
        // *-8 to convert to a range of 0-8 for the spinner segments
        // +8 to avoid negative indices
        GetComponent<Image>().color = SpinnerManager.instance.segmentColors[spinnerRegion];
    }

    public void OnClick()
    {
        if(SpinnerManager.instance.activeSpinner != buttonIndex)
        {
            Debug.LogWarning("Clicked spinner button that is not active.");
            return;
        }
        SpinnerManager.instance.Hit(spinnerRegion);
    }
}
