using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{

    RoomManager rm;

    public int currentMinigameIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (rm != null && rm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            rm = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
        currentMinigameIndex = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startMiniGameButtonPressed() 
    {
        SceneManager.LoadScene(currentMinigameIndex);

    }

}
