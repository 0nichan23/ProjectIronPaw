using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
	
		// Audio players components.
		public AudioSource EffectsSource;
		public AudioSource MusicSource;
		public AudioSource PlayerSource;

		public List<AudioClip> SfxClips = new List<AudioClip>();
	
	// Random pitch adjustment range.
	public float LowPitchRange = .95f;
		public float HighPitchRange = 1.05f;

		public AudioClip BgMusic;

		private void Start()
		{
			PlayMusic(BgMusic);


		}

		// Play a single clip through the sound effects source.
		public void Play(AudioClip clip)
		{
			EffectsSource.clip = clip;
			EffectsSource.Play();
		}

		// Play a single clip through the music source.
		public void PlayMusic(AudioClip clip)
		{
			MusicSource.clip = clip;
			MusicSource.Play();
		}
		public void PlayPlayer(AudioClip clip)
		{
			PlayerSource.clip = clip;
			PlayerSource.Play();
		}

		// Play a random clip from an array, and randomize the pitch slightly.
		public void RandomSoundEffect(AudioClip[] clips)
		{

			EffectsSource.Play();
		}
	}


