using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenuControlScript : MonoBehaviour
{
    
    [SerializeField] Dropdown _dropdownDifficulty;
    [SerializeField] Toggle _toggleMusic;

     [SerializeField] Toggle _toggleSFX;
    [SerializeField] Button _backButton;

 
    
        void Start()
    {
        _dropdownDifficulty.value = SingletonGameApplicationManager.Instance.
DifficultyLevel;
        _toggleMusic.isOn = SingletonGameApplicationManager.Instance.MusicEnabled;
        _toggleSFX.isOn = SingletonGameApplicationManager.Instance.SFXEnabled;

        _dropdownDifficulty.onValueChanged.AddListener(delegate {
            DropdownDifficultyChanged(_dropdownDifficulty);});
        _toggleMusic.onValueChanged.AddListener(delegate { OnToggleMusic(_toggleMusic);});
        _toggleSFX.onValueChanged.AddListener(delegate { OnToggleSFX(_toggleSFX);});
        _backButton.onClick.AddListener(delegate { BackButtonClick(_backButton);});

    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void BackButtonClick(Button button) {
    SceneManager.UnloadSceneAsync("SceneOptions");
    GameApplicationManager.Instance.IsOptionMenuActive =false;
    }
    
    public void DropdownDifficultyChanged(Dropdown dropdown) {
        GameApplicationManager.Instance.DifficultyLevel = dropdown.value;
        }
        
 public void OnToggleMusic(Toggle toggle) {
            
    SingletonGameApplicationManager.Instance.MusicEnabled = _toggleMusic.isOn;
    if (SingletonGameApplicationManager.Instance.MusicEnabled)
        SingletonSoundManager.Instance.MusicVolume = SingletonSoundManager.Instance.
            MusicVolumeDefault;
     else
        SingletonSoundManager.Instance.MusicVolume = SingletonSoundManager.
            MUTE_VOLUME;
           
            }
            
            public void OnToggleSFX(Toggle toggle)
{GameApplicationManager.Instance.SFXEnabled = _toggleSFX.isOn;

    if (SingletonGameApplicationManager.Instance.SFXEnabled)
        SingletonSoundManager.Instance.MasterSFXVolume = SingletonSoundManager.
            Instance.MasterSFXVolumeDefault;
    else
        SingletonSoundManager.Instance.MasterSFXVolume = SingletonSoundManager.
        MUTE_VOLUME;



}

}
