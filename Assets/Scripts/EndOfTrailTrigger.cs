using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndOfTrailTrigger : MonoBehaviour
{
    public GridBuildingSystem gridSystem;
    [HideInInspector] public float totalScore = 0f, pilgrimScore = 0f, numOfPilgrimsFinished = 0f; 
    public int endGamePilgrimNum = 10;

    public TextMeshProUGUI totalScoreText, pilgrimsFinishedText, demolishAllowanceText, endScoreText;

    public GameObject endUI, gameUI, startUI, controlsUI;

    public MousePosition mousePos;

    private void Start()
    {
        mousePos.enabled = false;
        Time.timeScale = 0f;

        startUI.SetActive(true);
        controlsUI.SetActive(false);
        gameUI.SetActive(false);
        endUI.SetActive(false);
    }

    private void Update()
    {
        totalScore = Mathf.Clamp(pilgrimScore / numOfPilgrimsFinished, 0f, 100f);

        if (numOfPilgrimsFinished > 0)
        {
            totalScoreText.text = totalScore.ToString("00");
        }
        else totalScoreText.text = "0";

        demolishAllowanceText.text = gridSystem.demolishAllowance.ToString() + " Demolishes Available";

        pilgrimsFinishedText.text = numOfPilgrimsFinished.ToString() + " Pilgrims Finished";

        if (numOfPilgrimsFinished >= endGamePilgrimNum)
        {
            EndGame();
        }

    }

    void TrackScore(PilgrimAI pilgrim)
    {
        string resolution = pilgrim.statToEnrich;

        switch (resolution)
        {
            case "Physical":
                {
                    pilgrimScore += pilgrim.physicalStat;
                    break;
                }
            case "Mental":
                {
                    pilgrimScore += pilgrim.mentalStat;
                    break;
                }
            case "Social":
                {
                    pilgrimScore += pilgrim.socialStat;
                    break;
                }
            case "Spiritual":
                {
                    pilgrimScore += pilgrim.spiritualStat;
                    break;
                }
        }

        totalScore = (pilgrimScore / numOfPilgrimsFinished);

        totalScoreText.text = totalScore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PilgrimAI>())
        {
            gridSystem.demolishAllowance++;
            demolishAllowanceText.text = gridSystem.demolishAllowance.ToString() + " Demolishes Available";

            numOfPilgrimsFinished++;
            pilgrimsFinishedText.text = numOfPilgrimsFinished.ToString() + " Pilgrims Finished";

            TrackScore(collision.GetComponent<PilgrimAI>());
        }
    }

    //public float TrackPilgrimScore(PilgrimAI pilgrim)
    //{
    //    return pilgrimScoreEffectOnTotal = ((totalScore + pilgrimScoreEffectOnTotal) / numOfPilgrimsFinished + 1) - totalScore;
    //}

    void EndGame()
    {
        Time.timeScale = 0f;


        startUI.SetActive(false);
        controlsUI.SetActive(false);
        endUI.SetActive(true);
        gameUI.SetActive(false);

        endScoreText.text = "You got " + totalScore.ToString("000") + " / 100";
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        mousePos.enabled = true;


        startUI.SetActive(false);
        controlsUI.SetActive(false);
        gameUI.SetActive(true);
        endUI.SetActive(false);

    }

    public void ShowControls()
    {
        startUI.SetActive(false);
        controlsUI.SetActive(true);
        gameUI.SetActive(false);
        endUI.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
