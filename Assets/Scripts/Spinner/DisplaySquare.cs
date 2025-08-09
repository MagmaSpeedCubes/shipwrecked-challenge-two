using UnityEngine;
using UnityEngine.UI;
public class DisplaySquare : MonoBehaviour
{
    [SerializeField] private int index;
    void Update()
    {
        GetComponent<Image>().color = SpinnerManager.instance.segmentColors[SpinnerManager.instance.hitColorIndices[index]];
    }
}
