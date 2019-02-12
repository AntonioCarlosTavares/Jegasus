using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GeradorDeCanosX : MonoBehaviour {

	public float alturaMax; //Altura maxima dos canos
	public float altunaMin; //Altura minima dos canos
	public float rateSpawn; //Tempo de respaw do canos
	private float currentSpawn; //Tempo atual de respaw dos canos
	public GameObject canoPrefab; // Obejto cano prefab
	public int maxSpawnCano; //Maximo de canos na tela
	private GameController gameController;
	public List <GameObject> canos; 


	void Start () 
	{
		gameController = FindObjectOfType(typeof(GameController)) as GameController;
			


		for (int i=0; i< maxSpawnCano; i++)
		{
			GameObject tempCano = Instantiate(canoPrefab) as GameObject;
			canos.Add(tempCano);
			tempCano.SetActive(false);
		}

		currentSpawn = rateSpawn;
	}

	void Update () 
	{
		if(gameController.GetCurrentState() != GameStates.INGAME)
			return;

		currentSpawn += Time.deltaTime;
		if (currentSpawn > rateSpawn)
		{
			currentSpawn = 0;
			Spawn();
		}
	}

	private void Spawn ()
	{
		float alturaRdn = Random.Range(altunaMin, alturaMax);
		
		GameObject tempCano = null;

		for(int i=0; i < maxSpawnCano; i++)
		{
			if(canos[i].activeSelf == false)
			{
				tempCano = canos[i];
				break;
			}
		}
		if(tempCano !=null)
		{
			tempCano.transform.position = new Vector3(transform.position.x, alturaRdn, transform.position.z);
			tempCano.SetActive(true);
		}
	}

}
