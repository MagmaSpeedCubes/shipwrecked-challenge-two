using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class RoomManager : MonoBehaviour
{

    RoomManager rm;

    public int currentMinigameIndex;

    public Vector3 previousPlayerPosition;

    public List<string> doorList = new List<string>();

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
        PlayerPrefs.SetInt("Level", 0);


    }

    // Update is called once per frame
    void Update()
    {
        int levelIndex = PlayerPrefs.GetInt("Level");
        if (levelIndex > currentMinigameIndex)
        {
            Debug.Log("ewe");
            currentMinigameIndex = levelIndex;

            minigameWasWon();
        }
        
    }

    public void startMiniGameButtonPressed() 
    {
        previousPlayerPosition = GameObject.Find("Player").transform.position;

        SceneManager.LoadScene(currentMinigameIndex + 1, LoadSceneMode.Single);

    }

    public void minigameWasWon()
    {


        SceneManager.LoadScene(0, LoadSceneMode.Single);

        StartCoroutine(waitAFrame()); 

    }

    public IEnumerator waitAFrame()
    {

        yield return null;

        GameObject.Find("Player").transform.position = previousPlayerPosition;

        yield return null;

        setLocks();
    }

    public void minigameWasLost()
    {

        SceneManager.LoadScene(0, LoadSceneMode.Single);

        StartCoroutine(waitAFrame()); 

    }

    public void setLocks()
    {
        if (currentMinigameIndex >= 1)
        {
            GameObject.Find(doorList[1]).GetComponent<DoorScript>().locked = false;
            GameObject.Find(doorList[1]).GetComponent<DoorScript>().ForceUpdate();
        }

        if (currentMinigameIndex >= 2)
        {
            GameObject.Find(doorList[2]).GetComponent<DoorScript>().locked = false;
            GameObject.Find(doorList[2]).GetComponent<Collider2D>().isTrigger = true;
        }

        if (currentMinigameIndex >= 3)
        {
            GameObject.Find(doorList[3]).GetComponent<DoorScript>().locked = false;
            GameObject.Find(doorList[3]).GetComponent<Collider2D>().isTrigger = true;
        }

    }

}
