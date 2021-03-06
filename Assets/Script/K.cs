using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;

public static class K
{
    public static IngameMap curMap = null;
    public static CinemachineConfiner CinemachineConfiner
    {
        get
        {
            if (!cinemachineConfiner)
                cinemachineConfiner = Object.FindObjectOfType<CinemachineConfiner>();
            return cinemachineConfiner;
        }
    }
    private static CinemachineConfiner cinemachineConfiner = null;

    public static PostProcessVolume PostProcessVolume
    {
        get
        {
            if (!postProcessVolume)
                postProcessVolume = Object.FindObjectOfType<PostProcessVolume>();
            return postProcessVolume;
        }
    }

    private static PostProcessVolume postProcessVolume = null;

    public static bool moveable = true;
    public static bool moveableX = true;
    public static bool moveableY = true;
    public static bool camable = true;

    public static List<HintInfo> hintInfos = new List<HintInfo>();

    public static Diagram diagram = null;
    public static HintUI hintUI = null;

    public static PlayerMove playerMove = null;
}
