using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {get; private set;}
    [SerializeField] private  AudioClip soundEnvironment;
    [SerializeField] private List<AudioClip> listSound = new List<AudioClip>();
    [SerializeField] private AudioSource soundSource;

    void Awake()
    {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySoundEnvironment(){
        if(soundEnvironment != null){
            soundSource.clip = soundEnvironment;
            soundSource.loop = true;
            soundSource.Play();
        }
    }


    public void PlaySoundEfect(int index){
        if(index >= 0 && index< listSound.Count && listSound[index]){
            soundSource.clip = listSound[index];
            soundSource.PlayOneShot(listSound[index]);
        }
    }


}
