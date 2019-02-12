using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.InputSources;

public class BtnMsg : MonoBehaviour {

	public GameObject target;
	public string message;

	void Start () 
	{
		GetComponent<PressGesture>().StateChanged+= HandleStateChanged;
	}

	void HandleStateChanged (object sender, TouchScript.Events.GestureStateChangeEventArgs e)
	{
		if(e.State == Gesture.GestureState.Ended){
			target.SendMessage(message, SendMessageOptions.RequireReceiver);
		}
	}

		void Update () 
	{
	
	}
	public void CallVoltar()
	{
		SoundController.PlaySound(soundGame.menu);
		Application.LoadLevel("Jegasus_1");	

	}
	public void CallFase2()
	{
		SoundController.PlaySound(soundGame.menu);
		Application.LoadLevel("Jegasus_2");
	}
	public void CallFase3()
	{
		SoundController.PlaySound(soundGame.menu);
		Application.LoadLevel("Jegasus_3");	
	}
}
