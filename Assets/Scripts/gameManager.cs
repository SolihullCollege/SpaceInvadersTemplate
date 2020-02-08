using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

    static bool isPlayerDead;
    public GameObject loseScreen;
    public GameObject winPanel;
    public Score scoreScript;

    [Header("DreamLO stuff")]
    //holds the text containers for score
    public GameObject highScores;
    //holds the leaderboard prefab here- from the DreamLO samples
    dreamloLeaderBoard dlBoard;
    Text[] scoreTxts;
    //max number of high scores to show must be the same as text fields
    public int maxToDisplay = 10;
    public GameObject inputName;

    // Use this for initialization
    void Start () {
        // get the reference to the prefab using the static function
        this.dlBoard = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
        
        scoreTxts = highScores.GetComponentsInChildren<Text>();
        highScores.SetActive(false);
        inputName.SetActive(false);

        isPlayerDead = false;
        loseScreen.SetActive(false);
        winPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayerDead)
        {
            loseScreen.SetActive(true);
            inputName.SetActive(true);
            isPlayerDead = false;
        }
        if(Score.score>45)
        {
            inputName.SetActive(true);
            winPanel.SetActive(true);
        }
	}

    public void UpdateLeaderBoard()
    {
        UpdateLeaderBoard(inputName.GetComponent<InputField>().text);
    }

    //Pass the string from an inputfield
    public void UpdateLeaderBoard(string playerName)
    {
        //whenever you want to update the score do the below
        dlBoard.AddScore(playerName, Score.score);
        inputName.SetActive(false);
        DisplayLeaderBoard();
    }

    //Called whenever you want to display leaderboard
    public void DisplayLeaderBoard()
    {
        //Get a list of scores from leaderboard sorted high to low
        List<dreamloLeaderBoard.Score> scoreList = dlBoard.ToListHighToLow();
        //activate the highscore list
        if (!highScores.activeInHierarchy)
        {
            highScores.SetActive(true);
        }

        //check to make sure there are scores
        if (scoreList.Count == 0)
        {
            //if not display a loading message and recall the leaderboard
            //this is to wait for values from server
            scoreTxts[0].text="loading...";
            StartCoroutine("waitForTime");
        }
        else
        {
            //loop through the score list and update the text fields
            for(int i=0;i<scoreTxts.Length;i++)
            {
                if(scoreList.Count>i)
                scoreTxts[i].text = scoreList[i].playerName + " :"+scoreList[i].score;
            }    
        }
    }

    IEnumerator waitForTime()
    {
        yield return new WaitForSeconds(1);
        DisplayLeaderBoard();
    }

    public static void playerDead()
    {
        isPlayerDead = true;


    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }
}
