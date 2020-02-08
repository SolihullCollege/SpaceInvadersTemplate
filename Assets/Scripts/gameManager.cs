using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

    static bool isPlayerDead;
    public GameObject loseScreen;
    public Score scoreScript;

    [Header("DreamLO stuff")]
    //holds the leaderboard prefab here- from the DreamLO samples
    dreamloLeaderBoard dlBoard;
    //holds the text containers for score
    public GameObject highScores;
    Text[] scoreTxts;
    //max number of high scores to show
    public int maxToDisplay = 20;

    // Use this for initialization
    void Start () {
        // get the reference to the prefab using the static function
        this.dlBoard = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
        
        scoreTxts = highScores.GetComponentsInChildren<Text>();
        highScores.SetActive(false);

        isPlayerDead = false;
        loseScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayerDead)
        {
            loseScreen.SetActive(true);
            dlBoard.LoadScores();
            DisplayLeaderBoard();
            isPlayerDead = false;
        }
	}



    public void UpdateLeaderBoard(string playerName)
    {
        //whenever you want to update the score do the below
        dlBoard.AddScore(playerName, Score.score);
    }

    public void DisplayLeaderBoard()
    {
        List<dreamloLeaderBoard.Score> scoreList = dlBoard.ToListHighToLow();
        highScores.SetActive(true);

        if (scoreList.Count == 0)
        {
            scoreTxts[0].text="loading...";
            DisplayLeaderBoard();
        }
        else
        {
            for(int i=0;i<maxToDisplay;i++)
            {
                Debug.Log(scoreList.Count);
                if(scoreList.Count>i)
                scoreTxts[i].text = scoreList[i].playerName + " :"+scoreList[i].score;
            }    
        }
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
