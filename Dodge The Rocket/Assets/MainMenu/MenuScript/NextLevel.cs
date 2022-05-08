using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public static NextLevel callnextlevel;

    [SerializeField]
    private Canvas nextlevelCanvas;

    private void CallNextLevelUI()
    {
        nextlevelCanvas.gameObject.SetActive(true);
         SoundEffectManager.PlaySound("Win");
        
    }

    public void NextLevelTimer()
    {
        Invoke("CallNextLevelUI", 2f);
        
    }

    void Awake()
    {
        if (callnextlevel == null)
        {
            callnextlevel = this;
        }
    }

    public void NextScene()
    {
        if (
            SceneManager.GetActiveScene().buildIndex + 1 ==
            SceneManager.sceneCountInBuildSettings
        )
        {
            SceneManager.LoadScene(sceneName: "Main Scene");
        }
        else
        {
            SceneManager
                .LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
