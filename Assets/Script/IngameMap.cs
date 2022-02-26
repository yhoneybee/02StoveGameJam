using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class IngameMap : MonoBehaviour
{
    [SerializeField] public PolygonCollider2D polygonCollider2D;
    [SerializeField] private bool trigger;
    public void Setting()
    {
        K.curMap = this;
        K.CinemachineConfiner.m_BoundingShape2D = polygonCollider2D;
    }

    private void Start()
    {
        Test();
    }

    private void Update()
    {
        Test();
    }

    private void Test()
    {
        if (trigger)
        {
            trigger = false;
            Setting();
        }
    }
}
