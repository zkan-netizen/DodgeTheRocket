using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider _isCol)
    {
        if (
            _isCol.gameObject.tag == "RotaryBlock" ||
            _isCol.gameObject.tag == "LaserProtecter"
        )
        {
            PlayerController.PlayerAnim.SetBool("WillDeath", true);
            Debug.Log("KillPlayerrr");
            PlayerController.Speed = 0;

            if (PlayerController.Speed == 0)
            {
                PlayerController.PlayerAnim.SetBool("StopWait", true);
            }
            GameOverScript._callgameover.GameOverTimer();
        }
        else
        {
            PlayerController.PlayerAnim.SetBool("WillDeath", false);
        }
        if (_isCol.gameObject.tag == "Key")
        {
            GameObject.FindWithTag("LaserProtect").SetActive(false);
            GameObject.FindWithTag("Key").SetActive(false);
            Debug.Log("KeyTookLazerSystemsAreDeactive");
        }
    }
}
