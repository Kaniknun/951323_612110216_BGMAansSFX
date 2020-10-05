using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SingletonSoundManager : Singleton<SingletonSoundManager>
{
   
    public const float MUTE_VOLUME = -80;
    [SerializeField]
    protected AudioMixer mixer;
    public AudioMixer Mixer {get{return mixer;}set{ mixer =value; } }
  
        public AudioSource BGMSource{get;set;}
            #region Music Volume
            public float MusicVolumeDefault{get;set;}

            protected float musicVolume;
            public float MusicVolume
        {
                get
                {
                return this.musicVolume;
                }
                set
                {
                this.musicVolume = value;
                SingletonSoundManager.Instance.Mixer.SetFloat("MusicVolume", this.musicVolume
                );
        }
    }
    #endregion
            
            
            
            
            #region SFX Volume
            protected float masterSFXVolume;
            public float MasterSFXVolume
            {
                get
                {
                    return this.masterSFXVolume;
                    }
                    set
                    {
                        this.masterSFXVolume =value;
                        SingletonSoundManager.Instance.Mixer.SetFloat("MasterSFXVolume",this.masterSFXVolume);
                        }
                }
             public float MasterSFXVolumeDefault { get;set; }


        #endregion


    private void Awake()
 {
        this.BGMSource = this.GetComponent <AudioSource >();

        float musicVolume;
        if (mixer.GetFloat("MusicVolume", out musicVolume))
            SingletonSoundManager.Instance.MusicVolumeDefault = musicVolume;
         float masterSFXVolume;
        if (mixer.GetFloat("MasterSFXVolume", out masterSFXVolume))
            SingletonSoundManager.Instance.MasterSFXVolumeDefault = masterSFXVolume;
 }

            
                        
}

