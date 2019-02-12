using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {


	public TextMesh scorePoints;
	public Renderer[] medals;
	public GameObject content;
	public GameObject title;
	public GameObject newRecord;
	public GameObject newRecordMedalha;
	public GameObject fadeColisao;
	private int prata;
	private int ouro;
	private int bronze;

	private int totalPrata;
	private int totalOuro;
	private int totalBronze;
	//private int recorde;





	void Start () 
	{
		HideGameOver();


	}
	

	void Update () 
	{


	}




	public void SetGameOver (int scoreInGame)
	{
		if(scoreInGame > PlayerPrefs.GetInt(Application.loadedLevelName))
		{
			PlayerPrefs.SetInt(Application.loadedLevelName, scoreInGame);
			newRecord.SetActive(true);
			
		}
		else
		{
			newRecord.SetActive(false);
		}



		scorePoints.text = scoreInGame.ToString();

		//verifica qual fase foi escolhida
		if(Application.loadedLevelName == "Jegasus_1"){
			if(scoreInGame >= 10 && scoreInGame <=19)
			{
				totalBronze = PlayerPrefs.GetInt("TotalBronzeL1");
				medals[0].enabled = true;
				PlayerPrefs.SetInt("BronzeL1", ++bronze);

				Debug.Log("ganhou: "+bronze+" bronze");

				totalBronze += 1;
				PlayerPrefs.SetInt("TotalBronzeL1", totalBronze);
				Debug.Log("total: "+totalBronze+" bronze");

			}
			else if(scoreInGame >=20 && scoreInGame <=39)
			{
				totalPrata = PlayerPrefs.GetInt("TotalPrataL1");
				medals[1].enabled = true;
				PlayerPrefs.SetInt("PrataL1", ++prata);

				Debug.Log("ganhou: "+prata+" Prata");
				
				totalPrata += 1;
				PlayerPrefs.SetInt("TotalPrataL1", totalPrata);
				Debug.Log("total: "+totalPrata+" prata");
				
			}
			else if(scoreInGame >=40)
			{
				totalOuro = PlayerPrefs.GetInt("TotalOuroL1");
				medals[2].enabled = true;
				PlayerPrefs.SetInt("OuroL1", ++ouro);

				Debug.Log("ganhou: "+ouro+" ouro");
				
				totalOuro += 1;
				PlayerPrefs.SetInt("TotalOuroL1", totalOuro);
				Debug.Log("total: "+totalOuro+" ouro");
				
			}
		}
		//verifica qual fase foi escolhida
		if(Application.loadedLevelName == "Jegasus_2"){
			if(scoreInGame >= 10 && scoreInGame <=19)
			{
				totalBronze = PlayerPrefs.GetInt("TotalBronzeL2");
				medals[0].enabled = true;
				PlayerPrefs.SetInt("BronzeL2", ++bronze);
				
				Debug.Log("ganhou: "+bronze+" bronze");
				
				totalBronze += 1;
				PlayerPrefs.SetInt("TotalBronzeL2", totalBronze);
				Debug.Log("total: "+totalBronze+" bronze");

			}
			else if(scoreInGame >=20 && scoreInGame <=39)
			{
				totalPrata = PlayerPrefs.GetInt("TotalPrataL2");
				medals[1].enabled = true;
				PlayerPrefs.SetInt("PrataL2", ++prata);
				
				Debug.Log("ganhou: "+prata+" Prata");
				
				totalPrata += 1;
				PlayerPrefs.SetInt("TotalPrataL2", totalPrata);
				Debug.Log("total: "+totalPrata+" prata");
				
			}
			else if(scoreInGame >=40)
			{
				totalOuro = PlayerPrefs.GetInt("TotalOuroL2");
				medals[2].enabled = true;
				PlayerPrefs.SetInt("OuroL2", ++ouro);
				
				Debug.Log("ganhou: "+ouro+" ouro");
				
				totalOuro += 1;
				PlayerPrefs.SetInt("TotalOuroL2", totalOuro);
				Debug.Log("total: "+totalOuro+" ouro");
				
			}
		}
		//verifica qual fase foi escolhida
		if(Application.loadedLevelName == "Jegasus_3"){
			if(scoreInGame >= 10 && scoreInGame <=19)
			{
				totalBronze = PlayerPrefs.GetInt("TotalBronzeL3");
				medals[0].enabled = true;
				PlayerPrefs.SetInt("BronzeL3", ++bronze);
				Debug.Log("ganhou: "+bronze+" bronze");


				//totalBronze = PlayerPrefs.GetInt("BronzeL3");

				//PlayerPrefs.SetInt("TotalBronzeL3", totalBronze);
				//if(PlayerPrefs.GetInt("TotalBronzeL3") >= PlayerPrefs.GetInt("BronzeL3")){
					totalBronze += 1;
					PlayerPrefs.SetInt("TotalBronzeL3", totalBronze);
					Debug.Log("total: "+totalBronze+" bronze");
				//}
				
			}
			else if(scoreInGame >=20 && scoreInGame <=39)
			{
				totalPrata = PlayerPrefs.GetInt("TotalPrataL3");
				medals[1].enabled = true;
				PlayerPrefs.SetInt("PrataL3", ++prata);
				
				Debug.Log("ganhou: "+prata+" Prata");
				
				totalPrata += 1;
				PlayerPrefs.SetInt("TotalPrataL3", totalPrata);
				Debug.Log("total: "+totalPrata+" prata");
				
			}
			else if(scoreInGame >=40)
			{
				totalOuro = PlayerPrefs.GetInt("TotalOuroL3");
				medals[2].enabled = true;
				PlayerPrefs.SetInt("OuroL3", ++ouro);
				
				Debug.Log("ganhou: "+ouro+" ouro");
				
				totalOuro += 1;
				PlayerPrefs.SetInt("TotalOuroL3", totalOuro);
				Debug.Log("total: "+totalOuro+" ouro");
				
			}
		}
	

		content.SetActive(true);
		title.SetActive(true);

		content.GetComponent<Animator>().SetBool("CallGameOver", true);
		title.GetComponent<Animator>().SetBool("CallGameOver", true);

	}

	public void HideGameOver()
	{
		title.SetActive(false);
		content.SetActive(false);
		foreach(Renderer m in medals)
		{
			m.enabled = false;
		}

		if(fadeColisao.activeSelf)

		fadeColisao.GetComponent<Animator>().SetBool("FadeColisao",false);
		fadeColisao.SetActive(false);
	
	}
	public void ShowFade()
	{
		fadeColisao.SetActive(true);
		fadeColisao.GetComponent<Animator>().SetBool("FadeColisao",true);
	}

}
