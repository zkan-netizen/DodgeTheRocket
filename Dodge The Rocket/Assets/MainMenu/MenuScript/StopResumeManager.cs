using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopResumeManager : MonoBehaviour
{
    public GameObject PauseMenuUI;

    // Start is called before the first frame update


public void MuteSound(){
    AudioListener.volume = 0;
}
public void EnableSound(){
    AudioListener.volume = 1;
}





    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
