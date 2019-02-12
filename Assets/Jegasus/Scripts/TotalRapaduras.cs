using UnityEngine;
using System.Collections;

public class TotalRapaduras : MonoBehaviour {
	public TextMesh qtdMedalhas;
	public string medalha;
	private int total;
	private string txtTotal;

	void Start () 
	{
		//Debug.Log(PlayerPrefs.GetInt(medalha));
	}
	
	void Update () 
	{
		txtTotal = total.ToString ();

			total = PlayerPrefs.GetInt(medalha);
			qtdMedalhas.text = total.ToString();

	}
}
