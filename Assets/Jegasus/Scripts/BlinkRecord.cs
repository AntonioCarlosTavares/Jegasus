using UnityEngine;
using System.Collections;

public class BlinkRecord : MonoBehaviour {

	public float rateBlink;
	public float currentBlink;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentBlink += Time.deltaTime;
		if(currentBlink > rateBlink)
		{
			GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
			currentBlink = 0;
		}
	}
}
