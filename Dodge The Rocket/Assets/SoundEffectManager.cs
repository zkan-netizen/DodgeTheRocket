using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public static AudioClip

            Bang,
            Run,
            Win,
            Lose,
            Catch;

    static AudioSource aSource;

    private void Start()
    {
        Bang = Resources.Load<AudioClip>("Bang");
        Win = Resources.Load<AudioClip>("Win");
        Lose = Resources.Load<AudioClip>("Lose");
        Catch = Resources.Load<AudioClip>("Catch");
        aSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Bang":
                aSource.PlayOneShot (Bang);
                break;
            case "Win":
                aSource.PlayOneShot (Win);
                break;
            case "Lose":
                aSource.PlayOneShot (Lose);
                break;
            case "Catch":
                aSource.PlayOneShot (Catch);
                break;
        }
    }
}
