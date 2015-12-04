using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour {

	public AudioClip[] soundTrack = new AudioClip[4];
	public AudioSource soundSource = new AudioSource();

	public int song = 0;

	// Use this for initialization
	void Start () {
		song = Random.Range (0, 4);
		playNextSong ();
	}

	void playNextSong () {
		soundSource.clip = soundTrack[song];
		soundSource.Play();
		Invoke ("PlayNextSong", soundSource.clip.length);
		if (song < soundTrack.Length - 1) {
			song++;
		}
		else {
			song = 0;
		}
	}
}
