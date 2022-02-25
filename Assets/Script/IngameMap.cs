using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class IngameMap : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D polygonCollider2D;
    void Start()
    {
        K.curMap = this;
        K.CinemachineConfiner.m_BoundingShape2D = polygonCollider2D;
    }
}
