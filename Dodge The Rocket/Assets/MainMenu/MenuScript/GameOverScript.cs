using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public static GameOverScript _callgameover;

    [SerializeField]
    private Canvas _gameOver;

    private void CallGameOverUI()
    {
        _gameOver.gameObject.SetActive(true);
        Time.timeScale = 0;
        SoundEffectManager.PlaySound("Lose");
        PlayerController.Speed=5;
    }

    public void GameOverTimer()
    {
        
        Invoke("CallGameOverUI", 2f);
    }

    void Awake()
    {
        if (_callgameover == null)
        {
            _callgameover = this;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
