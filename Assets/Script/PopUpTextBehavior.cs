using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpTextBehavior : MonoBehaviour
{
    [SerializeField]
    Text scoreTxt;

    private Vector3 startpos;
    private Vector3 endpos;
    private float Score;
    private float textMoveDelta;

    public void InitializeText(float score, Vector3 start, Vector3 end)
    {
        Score = score;
        startpos = Camera.main.WorldToScreenPoint(start);
        endpos = end;
        scoreTxt.text = Score.ToString();
        textMoveDelta = 0.0f;
    }
	
	
	// Update is called once per frame
	void Update ()
    {
		if(textMoveDelta >= 1.0f)
        {
            ScoreKeeper.instance.AddScore(Score);
            Destroy(gameObject);
        }
        else
        {
            textMoveDelta += Time.deltaTime * 3.0f;
            transform.position = Vector3.Lerp(startpos, endpos, textMoveDelta);
        }
	}
}
