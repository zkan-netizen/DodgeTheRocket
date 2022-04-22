using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentGuardScript : MonoBehaviour
{
   public static bool SpotterCondition = true;

    Vector3 startAngles = new Vector3(0, -130, 0);

    Vector3 endAngles = new Vector3(0, -50, 0);

    Quaternion

            startRot,
            endRot;

    public float speed = 0.5f;

    void Start()
    {
        startRot = Quaternion.Euler(startAngles);
        endRot = Quaternion.Euler(endAngles);
        transform.rotation = startRot;
    }

    void Guard()
    {
        if (SpotterCondition == true)
        {
            transform.rotation =
                Quaternion
                    .Lerp(startRot,
                    endRot,
                    (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
        }
    }

    void Update()
    {
        Guard();
    }
}
