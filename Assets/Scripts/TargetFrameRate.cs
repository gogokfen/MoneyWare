using UnityEngine;

public class TargetFrameRate : MonoBehaviour
{
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
    }
}