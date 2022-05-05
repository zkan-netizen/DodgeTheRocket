using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicSettings : MonoBehaviour
{
    public void LowGraphic()
    {
        QualitySettings.SetQualityLevel(1);
    }
     public void MediumGraphic()
    {
        QualitySettings.SetQualityLevel(3);
    }
     public void HighGraphic()
    {
        QualitySettings.SetQualityLevel(5);
    }
     public void VeryHighGraphic()
    {
        QualitySettings.SetQualityLevel(6);
    }
}
