using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApplicationManager : MonoBehaviour
{
    static public GameApplicationManager Instance {
       get{
           if(_instance ==null)
            {
                _instance = GameObject.FindObjectOfType<GameApplicationManager>();
                GameObject container =new GameObject("GameApplicationManager");
                _instance = container.AddComponent<GameApplicationManager>();
                }
                return _instance;
    }
 }
 static protected GameApplicationManager _instance =null;

    void Awake(){

if(_instance == null){
    _instance = this;
    DontDestroyOnLoad(this.gameObject);
}
else{
    if(this != _instance){
        Destroy(this.gameObject);
}
}
}

public string[] DIFFICULTY_LEVEL_NAMES = {"Easy","Normal","Hard","Extreme"};

public bool IsOptionMenuActive{
get{ return _isOptionMenuActive;}
set{ _isOptionMenuActive = value;}

}

protected bool _isOptionMenuActive = false;

public int DifficultyLevel{get;set;}
public bool MusicEnabled{get;set;}
public bool SFXEnabled{get;set;}


}
