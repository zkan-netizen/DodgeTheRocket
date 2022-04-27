using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider _isCol)
    {
        if (
            _isCol.gameObject.tag == "RotaryBlock" ||
            _isCol.gameObject.tag == "LaserProtect"
        )
        {
            Debug.Log("KillPlayerrr");
        }
        if (_isCol.gameObject.tag == "Key")
        {
            GameObject.FindWithTag("LaserProtect").SetActive(false);
            GameObject.FindWithTag("Key").SetActive(false);
            Debug.Log("KeyTookLazerSystemsAreDeactive");
        }
    }
}
