using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    //The mixer for all of the project audio.
    public AudioMixer mixer;

    // The sliders of each of the mixer channels.
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    // The mute button toggle.
    public Toggle mute;

    /*
    * Setting up listeners to react when there is a change in one of the sliders or the mute toggle.
    */
    void Awake(){
        masterSlider.onValueChanged.AddListener(setMasterVolume);
        musicSlider.onValueChanged.AddListener(setMusicVolume);
        sfxSlider.onValueChanged.AddListener(setSfxVolume);
        mute.onValueChanged.AddListener(muteAudio);
    }

    /*
    * A method to set the master volume.
    * @Params a float for the desired volume.
    */
    void setMasterVolume(float volume){
        // setting the volume
        mixer.SetFloat("masterVolume", Mathf.Log10(volume) * 20);

        // if the master volume is at minimum, it toggles the mute
        if(volume <= 0.00001){
            mute.isOn = true;
        } else if (mute.isOn == true){
            mute.isOn = false;
        }
    }

    /*
    * A method to set the volume of the music.
    * @Params a float for the desired volume.
    */
    void setMusicVolume(float volume){
        mixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20);
    }

    /*
    * A method to set the sound effects volume.
    * @Params a float for the desired volume.
    */
    void setSfxVolume(float volume){
        mixer.SetFloat("sfxVolume", Mathf.Log10(volume) * 20);
    }

    /*
    * A toggle to mute all audio.
    * @Params the new state of the toggle, true if muted, false otherwise.
    */
    public void muteAudio(bool mute){
        if (mute){
            AudioListener.volume = 0;
        } else {
            AudioListener.volume = 1;
        }
    }

}
