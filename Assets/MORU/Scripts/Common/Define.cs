using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum State
    {
        Die,
        Moving,
        Idle,
        Attack,
        Surprise,
        hide
    }

    public enum Map
    {
        Class,
        Toilet,
        Corridor
    }

    public enum Layer
    {
        Background = 6,
        Obstacle = 7
    }
}
