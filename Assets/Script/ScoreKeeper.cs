using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField]
    Text ScoreTxt;
    [SerializeField]
    Text PresentCountTxt;
    [SerializeField]
    Text EndScoreTxt;
    [SerializeField]
    Text EndPresentTxt;
    [SerializeField]
    Text EndDecorationTxt;
    [SerializeField]
    GameObject numText;

    [SerializeField]
    GameObject EndPanel;


    public static ScoreKeeper instance;

    private float Score;
    private int presentCount;
    private int decorationCount;

    private Vector3 scoreTXTPos;
    private Vector3 presentTXTPos;
    private Vector3 pointStartPos;
    private bool scoreTextMoving;
    private float scoreMovingDelta;
    private Text popUpText;
     
	// Use this for initialization
	void Start ()
    {
        instance = this;
        Score = 0.0f;
        presentCount = 0;
        decorationCount = 0;
        ScoreTxt.text = Score.ToString();
        PresentCountTxt.text = presentCount.ToString();
        scoreTXTPos = ScoreTxt.transform.position;
        presentTXTPos = Camera.main.WorldToScreenPoint(PresentCountTxt.transform.position);
	}

    private void Update()
    {
        if (scoreTextMoving)
        {
            if(scoreMovingDelta >= 1.0f)
            {
                scoreTextMoving = false;
                scoreMovingDelta = 0.0f; 
            }
            else
            {
                scoreMovingDelta += Time.deltaTime;
                popUpText.transform.position = Vector3.Lerp(pointStartPos, scoreTXTPos, scoreMovingDelta);
            }
        }
    }

    public void AddScore(float scoreAmount)
    {
        Score += scoreAmount;
        ScoreTxt.text = Score.ToString();
    }

    public void AddPresent()
    {
        presentCount++;
        PresentCountTxt.text = presentCount.ToString();
    }
    public void AddDecoration()
    {
        decorationCount++;
    }

    public void TurnOnEndPanel()
    {
        EndPanel.SetActive(true);
        EndScoreTxt.text = Score.ToString();
        EndDecorationTxt.text = decorationCount.ToString();
        EndPresentTxt.text = presentCount.ToString();
    }

    public void ReturnToTitle()
    {
        if (LevelManager.instance != null)
        {
            LevelManager.instance.LoadLevel("Title Scene");
        }
    }

    public void CreatePopUpText(float scoreVal, Vector3 pos)
    {
        var popUp = Instantiate(numText, Camera.main.WorldToScreenPoint(pos), Quaternion.identity, gameObject.transform);
        popUp.GetComponent<PopUpTextBehavior>().InitializeText(scoreVal, pos, scoreTXTPos);
    }

}
