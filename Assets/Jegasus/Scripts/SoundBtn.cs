using UnityEngine;
using System.Collections;

public class SoundBtn : MonoBehaviour {
	public Texture2D Som;
	public Texture2D Mudo;
	
	private GameController gamecontroller;
	public float sizebtn;
	private bool isMudo;
	public GameObject soundController;


	void Start () 
	{
		gamecontroller = FindObjectOfType(typeof(GameController)) as GameController;
		
	}
	void OnGUI()
	{
		if(gamecontroller.GetCurrentState() == GameStates.INGAME)
		{
			if(!isMudo)
			{
				if(GUI.Button(new Rect(Screen.width-80,Screen.height-50,sizebtn, sizebtn), Mudo, GUIStyle.none))
				{
					isMudo= true;
					soundController.SetActive(false);
					
					
				}
				
			}
			else{
				if(GUI.Button(new Rect(Screen.width-80,Screen.height-50,sizebtn, sizebtn), Som, GUIStyle.none)){
					
					isMudo = false;
					soundController.SetActive(true);
					
					
				}
			}
		}
		
	}
	public bool IsPaused()
	{
		return isMudo;
	}
}


