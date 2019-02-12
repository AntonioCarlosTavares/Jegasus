using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

	public Texture2D pause;
	public Texture2D play;
	private GameController gamecontroller;
	public float sizebtn;
	private bool isPause;



	void Start () 
	{
		gamecontroller = FindObjectOfType(typeof(GameController)) as GameController;
	
	}
	void OnGUI()
	{
		if(gamecontroller.GetCurrentState() == GameStates.INGAME)
			{
			if(!isPause)
				{
				if(GUI.Button(new Rect(Screen.width-140,Screen.height-50,sizebtn, sizebtn), pause, GUIStyle.none))
			   		{
						isPause = true;
						Time.timeScale = 0;


					}

				}
				else{
				if(GUI.Button(new Rect(Screen.width-140,Screen.height-50,sizebtn, sizebtn), play, GUIStyle.none)){
				
					isPause = false;
					Time.timeScale = 1;
					
					
				}
			}
		}
	
	}
	public bool IsPaused()
	{
		return isPause;
	}
}


