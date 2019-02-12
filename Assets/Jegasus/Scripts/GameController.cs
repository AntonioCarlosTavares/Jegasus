using UnityEngine;
using System.Collections;

public enum GameStates
{
	START,
	WAITGAME,
	MAINMENU,
	TUTORIAL,
	INGAME,
	GAMEOVER,
	RANKING,

}

public class GameController : MonoBehaviour {

	public Transform player;
	private Vector3 startPositionPlayer;
	private GameStates curretState = GameStates.START;
	public TextMesh numberScore;
	public TextMesh textScore;
	private int score;
	public float timeToRestart;
	private float currentTimeToRestart;
	private GameOverController gameOverM;
	private bool canPlay;
	public GameObject mainMenu;
	public GameObject tutorial;
	private float currentTimeToPlayAgain;
	public GameObject pontos;


	void Start () 
	{
		startPositionPlayer = player.position;
		gameOverM = FindObjectOfType(typeof(GameOverController)) as GameOverController;

	}
	
	void Update () 
	{
		switch(curretState)
		{
			case GameStates.START:
			player.position = startPositionPlayer;
			curretState = GameStates.MAINMENU;
			mainMenu.SetActive(true);
										
		{
		
		}
		break;
		
		case GameStates.MAINMENU:
		{
			player.position = startPositionPlayer;
			player.gameObject.SetActive(false);
			tutorial.SetActive(false);
			pontos.SetActive(false);

						
		}
		
			break;
		
		case GameStates.TUTORIAL:
			tutorial.SetActive(true);
		{
			player.position = startPositionPlayer;

			currentTimeToPlayAgain += Time.deltaTime;

			if(currentTimeToPlayAgain > 0.7f)
			{
				currentTimeToPlayAgain = 0;
				canPlay = true;
			}
		}
			
		break;

		case GameStates.WAITGAME:
		{
			player.position = startPositionPlayer;

		}
		
		break;
		
		case GameStates.INGAME:
		{
			//AdvertisementHandler.HideAds();
			numberScore.text = score.ToString();
			pontos.SetActive(true);

		}
		break;
		
		case GameStates.GAMEOVER:
		{
			currentTimeToRestart += Time.deltaTime;
			if(currentTimeToRestart > timeToRestart)
			{
				currentTimeToRestart = 0;
				curretState = GameStates.RANKING;
				gameOverM.SetGameOver(score);
				canPlay = false;




			}
		
		}
		break;
		
		case GameStates.RANKING:
		{

			numberScore.GetComponent<Renderer>().enabled = false;
			textScore.GetComponent<Renderer>().enabled = false;
								
			
		}

			break;
		
		}

	}

	public void StartGame()
	{
		curretState = GameStates.INGAME;
		numberScore.GetComponent<Renderer>().enabled = true;
		textScore.GetComponent<Renderer>().enabled = true;
		score = 0;
		gameOverM.HideGameOver();
		tutorial.SetActive(false);
	}

	public GameStates GetCurrentState()
	{
		return curretState;
	}

	public void CallGameOver()
	{
		if(curretState != GameStates.GAMEOVER && curretState != GameStates.RANKING){

			SoundController.PlaySound(soundGame.hit);
			gameOverM.ShowFade();
			curretState = GameStates.GAMEOVER;
		}



	
	}

	public void CallTutorial()
	{
		curretState = GameStates.TUTORIAL;
		mainMenu.SetActive(false);
		tutorial.SetActive(true);
		player.gameObject.SetActive(true);
		gameOverM.HideGameOver();
		ResetGame();
		SoundController.PlaySound(soundGame.menu);


	}
	public void CallMenu()
	{
		curretState = GameStates.MAINMENU;
		mainMenu.SetActive(true);
		player.gameObject.SetActive(false);
		gameOverM.HideGameOver();
		ResetGame();
		SoundController.PlaySound(soundGame.menu);
		
		
	}

	public void CallSelectLevel()
	{
		curretState = GameStates.MAINMENU;
		mainMenu.SetActive(true);
		player.gameObject.SetActive(false);
		gameOverM.HideGameOver();
		ResetGame();
		SoundController.PlaySound(soundGame.menu);
		Application.LoadLevel("LvlSelect");
		
		
	}
	public void CallQuit()
	{
		Application.Quit();		
	}

	public void ResetGame()
	{
		player.position = startPositionPlayer;
		player.GetComponent<PlayerMovimento>().ResetRotation();

		MovimentoCanos[] cano = FindObjectsOfType(typeof(MovimentoCanos)) as MovimentoCanos[];
		foreach (MovimentoCanos o in cano)
		{
			o.gameObject.SetActive(false);
		}

		numberScore.GetComponent<Renderer>().enabled = false;
		textScore.GetComponent<Renderer>().enabled = false;
		numberScore.text = score.ToString();


	}
	public void AddScore()
	{
		score++;
		SoundController.PlaySound(soundGame.point);
			
	}


	public bool CanPlay()
	{
		return canPlay;

	}
}