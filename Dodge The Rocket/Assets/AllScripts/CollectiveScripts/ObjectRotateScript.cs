using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotateScript : MonoBehaviour
{
    [SerializeField]private Vector3 Direction;
    [SerializeField]private int _objrotatespeed;
    void Rotater()
    {
        transform.Rotate(Direction, _objrotatespeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
Rotater();
    }
}
