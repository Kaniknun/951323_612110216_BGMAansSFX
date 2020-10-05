using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGameApplicationManager : Singleton<SingletonGameApplicationManager>
{
    public string[] DIFFICULTY_LEVEL_NAMES = { "Easy", "Normal", "Hard", "Extreme" };

/////////// Get/Set property declaration ////////////
 public bool IsOptionMenuActive
 {
 get { return _isOptionMenuActive;}

 set { _isOptionMenuActive = value; }
}
 protected bool _isOptionMenuActive = false;
 //////////////////////////////

 /////////// Shorter version of Get/Set property declaration ////////////
 // The C# compiler will generate the same as the above for you, automatically.
 public int DifficultyLevel{get;set;}
 public bool MusicEnabled { get; set; } = true;
 public bool SFXEnabled{get;set;} = true;
 ////////////////////////////////////////



}

