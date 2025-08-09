using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;

public class RoomManager : MonoBehaviour
{

    RoomManager rm;

    public int currentMinigameIndex;

    public Vector3 previousPlayerPosition;

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
        
        currentMinigameIndex = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            minigameWasWon();
        }
        
    }

    public void startMiniGameButtonPressed() 
    {
        previousPlayerPosition = GameObject.Find("Player").transform.position;

        SceneManager.LoadScene(currentMinigameIndex, LoadSceneMode.Single);

    }

    public void minigameWasWon()
    {
        currentMinigameIndex++;

        SceneManager.LoadScene(0, LoadSceneMode.Single);

        StartCoroutine(waitAFrame()); 

    }

    public IEnumerator waitAFrame()
    {

        yield return null;

        GameObject.Find("Player").transform.position = previousPlayerPosition;
    }

    public void minigameWasLost()
    {

        SceneManager.LoadScene(0, LoadSceneMode.Single);



    }

}
