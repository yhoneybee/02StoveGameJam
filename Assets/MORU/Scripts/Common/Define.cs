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
        Class,  //����
        Toilet, //ȭ���
        Corridor//����
    }

    public enum Layer
    {
        Background = 6,
        Obstacle = 7
    }
}
