using UnityEngine;
using System.Collections;

public class PlayerMovimento : MonoBehaviour {

	public Transform player;
	public float fly;
	private Animator animatorPlayer;
	private GameController gameController;
	private PauseController pausecontroller;




	void Start () 
	{
		animatorPlayer = player.GetComponent <Animator>();
		gameController = FindObjectOfType(typeof(GameController)) as GameController;
		pausecontroller = FindObjectOfType(typeof(PauseController)) as PauseController;
		//PlayerPrefs.DeleteAll(); //<-- Deleta ScoresRanking
	}	



	void Update () 
	{

		if(Input.GetMouseButtonDown(0) && 
		   gameController.GetCurrentState() == GameStates.INGAME &&
		   gameController.GetCurrentState() != GameStates.GAMEOVER &&
		   !pausecontroller.IsPaused())
		{
			animatorPlayer.SetBool("fly", true);

			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			
			GetComponent<Rigidbody2D>().AddForce(new Vector2 (0,1)* fly);

			SoundController.PlaySound(soundGame.wing);

		}
		else if(Input.GetMouseButtonDown(0) && gameController.GetCurrentState() == GameStates.TUTORIAL)
		{
			if(gameController.CanPlay())
			{
				Restart();
			}
	
		}
		else if (gameController.GetCurrentState() == GameStates.TUTORIAL)
		{

			animatorPlayer.SetBool("fly", true);

		}


		Vector3 positionPlayer = transform.position;

		if(positionPlayer.y > 11)
		{
			positionPlayer.y = 11;
			transform.position = positionPlayer;
		}

		if(gameController.GetCurrentState() != GameStates.INGAME && 
		   gameController.GetCurrentState() != GameStates.GAMEOVER)
		{
			GetComponent<Rigidbody2D>().gravityScale = 0;
			return;
		}
		else if (gameController.GetCurrentState() == GameStates.INGAME)
		{
			GetComponent<Rigidbody2D>().gravityScale = 1;
		}
		else
		{
			animatorPlayer.SetBool("fly", false);
		}
		if (gameController.GetCurrentState() == GameStates.INGAME)
		{
		if(GetComponent<Rigidbody2D>().velocity.y < 0)
		{
			player.eulerAngles -= new Vector3 (0,0,5f);
			if(player.eulerAngles.z < 270 && player.eulerAngles.z > 30)
				player.eulerAngles = new Vector3 (0,0,270);
		}
		else if (GetComponent<Rigidbody2D>().velocity.y > 0)
		{
			player.eulerAngles += new Vector3 (0,0,2f);
			if(player.eulerAngles.z > 30)
				player.eulerAngles = new Vector3 (0,0,30);
		}
			
		}
		else if(gameController.GetCurrentState() == GameStates.GAMEOVER)
		{
			player.eulerAngles -= new Vector3 (0,0,5f);
			if(player.eulerAngles.z < 270 && player.eulerAngles.z > 30)
				player.eulerAngles = new Vector3 (0,0,270);
		}
	}




	void OnCollisionEnter2D(Collision2D coll) 
	{
		gameController.CallGameOver();

	}

	void OnTriggerEnter2D(Collider2D coll) 
	{
		gameController.CallGameOver();
	}
	public void ResetRotation()
	{
		player.eulerAngles = new Vector3(0,0,0);
	}
	public void Restart()
	{

		if (gameController.GetCurrentState() != GameStates.GAMEOVER)
		{
			gameController.ResetGame();
			gameController.StartGame();
			
		}
	
	}

}







