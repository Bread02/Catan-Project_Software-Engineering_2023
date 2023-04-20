using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //an array of sounds storing every sound used.
    public Sound[] sounds;

    private bool muted;

//runs before everything.
//used to set up the different sounds given.
    void Awake(){
        muted = false;
        //setting up each sounds with the assigned values
        foreach(Sound sound in sounds){
            sound.audioSource = gameObject.AddComponent<AudioSource>();

            sound.audioSource.outputAudioMixerGroup = sound.group;
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.loop = sound.loop;
            sound.audioSource.volume = sound.volume;
        }
    }

/*
*   A method to play a given sound.
*   @params the name of the sound to be played.
*/
    public void PlaySound(string name){
        foreach(Sound sound in sounds){
            if(sound.name == name){
                sound.audioSource.Play();
                break;
            }
        }
    }

    public void clickSound(){
        PlaySound("click");
    }

}
