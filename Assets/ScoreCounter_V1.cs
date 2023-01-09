using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreCounter_V1 : MonoBehaviour
{

    //This initially started as JUST a score logic gameobj, but due to time constraints I'll just everything in here
    //Is it messy? Yes, but it's convinient.

    public TextMeshProUGUI scoreDisplay;
    public int scoreNum;
    public bool enemiesHaveSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreDisplay == null)
        {
            //FindGameObjectWithTag is a bit funky, so I have to combine it with GetComponent to specifically find a TextMeshProUGUI
            //Will have to keep this in mind in the future, as finding any object is possible, but I'll have to say what type of component it is
            //(If it isn't a GameObject)
            scoreDisplay = GameObject.FindGameObjectWithTag("ScoreLogicHUDTag").GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.SetText("Enemies Left: " + scoreNum);
        //If there's 5 enemies, text will appear as "Enemies Left: 5"
        if ((scoreNum == 0) && (enemiesHaveSpawned = true))
        {
            PlayerHasWon();
        }
    }

    public void PlayerHasWon()
    {
        Debug.Log("You won!");
        SceneManager.LoadScene("GameWonScene");
    }

    public void RemoveScore()
    {
        scoreNum -= 1;

        if (enemiesHaveSpawned == false)
        {
            enemiesHaveSpawned = true;
        }
    }

    public void AddScore()
    {
        scoreNum += 1;
    }
}
