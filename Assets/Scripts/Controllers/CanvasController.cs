using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityStandardAssets._2D;


/*<summary> 
   This Class is responsible for All controls the UI in the level Scene
</summary> */
public class CanvasController : MonoBehaviour {

    public Text textScore;
    public Text textTimer;
    public Image imageLifeBar;
    public GameObject finishPanel;

    private float timer;
    private float timerTial;
    private bool isTrialVersion;

    private const string DEFAULT_STRING_SCORE = "SCORE : {0}";

    // Use this for initialization
    void Start ()
    {
        if (VerifyInstanceGameObjects())
        {
            /*<summary> 
                 Instantiate Score
            </summary> */
            textScore.text = formatStringScore("00000000");

            /*<summary> 
                 Instantiate Watch.
                 if the version game is not trial the timer is Crescent, for Count the time it took the player to complete the level.
                 else The level must finish in the determined time. 
            </summary> */
            this.isTrialVersion = GameController.Instance.isTrialVersion;
            if (this.isTrialVersion)
            {
                timer = GameController.Instance.timeTrial;
                timerTial = timer;
            }
            else
            {
                timer = 0;
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (this.isTrialVersion)
        {
            if (!GameController.Instance.endlevel)
            {
                if (timer < 1)
                {
                    textTimer.text = "0";
                    gameOver();
                }
                else
                {
                    timer -= Time.deltaTime;
                    textTimer.text = timer.ToString();
                }
            }
        }
        else
        {
            if (!GameController.Instance.endlevel)
            {
                timer += Time.deltaTime;
            }
        }
	}

    public void addScorepoints(int points)
    {
        int actualScore = GameController.Instance.playerController.score;
        actualScore = actualScore + points;

        if (actualScore > 1000000)
        {
            textScore.text = formatStringScore(actualScore.ToString());
        }
        else if (actualScore > 100000)
        {
            textScore.text = formatStringScore(string.Format("0{0}", actualScore.ToString()));
        }
        else if (actualScore > 10000)
        {
            textScore.text = formatStringScore(string.Format("00{0}", actualScore.ToString()));
        }
        else if (actualScore > 1000)
        {
            textScore.text = formatStringScore(string.Format("000{0}", actualScore.ToString()));
        }
        else if (actualScore > 100)
        {
            textScore.text = formatStringScore(string.Format("0000{0}", actualScore.ToString()));
        }
        else if (actualScore > 10)
        {
            textScore.text = formatStringScore(string.Format("00000{0}", actualScore.ToString()));
        }

        GameController.Instance.playerController.score = actualScore;
    }

    private string formatStringScore(string actualScore)
    {
        return string.Format(DEFAULT_STRING_SCORE, actualScore);
    }

    private bool VerifyInstanceGameObjects()
    {
        bool result = true;

        if (textScore == null)
        {
            Debug.Log("Drag GameObject 'TextScore'(Type: UnityEngine.UI.Text) in Canvas Controller Script");
            result = false;
        }
        if (textTimer == null)
        {
            Debug.Log("Drag GameObject 'TextTimer'(Type: UnityEngine.UI.Text) in Canvas Controller Script");
            result = false;
        }
        if (imageLifeBar == null)
        {
            Debug.Log("Drag GameObject 'LifeBar'(Type: UnityEngine.UI.Image) in Canvas Controller Script");
            result = false;
        }

        return result;
    }

    public void setDamege(float damage)
    {
        if ((imageLifeBar.fillAmount - (damage / GameController.Instance.playerController.life) <= 0.1f))
        {
            imageLifeBar.fillAmount = 0;
            gameOver();
        }
        else
        {
            imageLifeBar.fillAmount = (imageLifeBar.fillAmount - (damage / GameController.Instance.playerController.life));
        }
    }

    public void gameOver()
    {
        finishPanel.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlatformerCharacter2D>().dontMove = true;
    }

    public void buttonActionRestarGame()
    {
        GameController.Instance.startGame();
        finishPanel.SetActive(false);
    }

    public void buttonActionReturnMenu()
    {
        GameController.Instance.LoadScene(GameController.ScenesNames.MenuGame.ToString());
    }
}
