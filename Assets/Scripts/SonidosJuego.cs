using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SonidosJuego : MonoBehaviour
{
    public static readonly string[] audioName = {"bitewav.wav", "failwav.wav"};
    [Header("Audio Stuff")]
    public AudioSource audioSource;
    public AudioClip audioClip;
    public string soundPath;

    public void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        soundPath = "file://" + Application.streamingAssetsPath + "/Sounds/";
        StartCoroutine(LoadAudio());
    }

    public IEnumerator LoadAudio()
    {
        WWW request = GetAudioFromFile(soundPath, audioName[0]);
        yield return request;

        audioClip = request.GetAudioClip();
        audioClip.name = audioName[0];
        PlayAudioFile();
    }

    public void PlayAudioFile()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        audioSource.loop = false;
    }

    private WWW GetAudioFromFile(string path, string filename)
    {
        string audioToLoad = string.Format(path + "{0}", filename);
        WWW request = new WWW(audioToLoad);
        return request;
    }
}