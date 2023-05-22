using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioClip hitSFX, backgroundMusic;
	private static AudioSource audioSrc;

	private static AudioManager instance;

	private void Awake()
	{
		if (instance)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(instance);

			hitSFX = Resources.Load<AudioClip>("Sounds/Hit SFX");
			backgroundMusic = Resources.Load<AudioClip>("Sounds/Background Music");

			audioSrc = GetComponent <AudioSource>();
		}
	}

	public static AudioManager GetInstance()
	{
		return instance;
	}

	public void PlayHitSound()
	{
		audioSrc.PlayOneShot(hitSFX);
	}

	public void PlayBackgroundMusic()
	{
		audioSrc.PlayOneShot(backgroundMusic);
	}
}
