	using UnityEngine;
	using System.Collections;

	public enum soundGame
	{
		die,
		hit,
		menu,
		point,
		wing,
		
	}

	public class SoundController : MonoBehaviour {
		public AudioClip die;
		public AudioClip hit;
		public AudioClip menu;
		public AudioClip point;
		public AudioClip wing;
		public static SoundController instance;


		void Start () 
		{
			instance = this;			
		}
		

		public static void PlaySound(soundGame currentSound)
		{
			switch(currentSound){
			
				case soundGame.die:{
					instance.GetComponent<AudioSource>().PlayOneShot(instance.die);
					
				}
				break;
				case soundGame.hit:{
					instance.GetComponent<AudioSource>().PlayOneShot(instance.hit);
					instance.Invoke("PlaySoundDie", 0.3f);
				}
				break;
				case soundGame.menu:{
					instance.GetComponent<AudioSource>().PlayOneShot(instance.menu);
				}
				break;
				case soundGame.point:{
					instance.GetComponent<AudioSource>().PlayOneShot(instance.point);
				}
				break;
				case soundGame.wing:{
					instance.GetComponent<AudioSource>().PlayOneShot(instance.wing);
				}
				break;
							
			}


		}
	private void PlaySoundDie(){
		PlaySound(soundGame.die);
	}

}
