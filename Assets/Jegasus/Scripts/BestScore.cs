using UnityEngine;
using System.Collections;



public class BestScore : MonoBehaviour {
	public TextMesh bestScoreFase1;
	public string fase;
	private int score;


	void Start () 
	{

	}
	

	void Update () 
	{
		score = PlayerPrefs.GetInt(fase);
		bestScoreFase1.text = score.ToString();

	}	
}
