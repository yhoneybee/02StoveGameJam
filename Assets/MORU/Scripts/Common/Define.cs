using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum AnimationType
    {
        Spine,
        Sprite
    }
    public enum State
    {
        Die,
        Moving,
        Idle,
        Attack,
        Surprise,
        Hide
    }

    public enum Map
    {
        Class,  //교실
        Toilet, //화장실
        Corridor//복도
    }

    public enum Layer
    {
        Background = 6,
        Obstacle = 7
    }
}
