using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class MainMenuControlScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void StartButtonClick(Button button) {
      SceneManager.LoadScene("SceneGameplay");
      }
      
      public void OptionsButtonClick(Button button) {
         if(!GameApplicationManager.Instance.IsOptionMenuActive)
         {
              SceneManager.LoadScene("SceneOptions", LoadSceneMode.Additive);
         GameApplicationManager.Instance.IsOptionMenuActive =true;
          }
         }
         
         public void ExitButtonClick(Button button) {
      Application.Quit();
      }
      
}

