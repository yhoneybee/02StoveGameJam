using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mirror : BasicObstacle
{
    [SerializeField] private RenderTexture renderTexture;
    [SerializeField] private Camera mirrorCam;
    [SerializeField] private RawImage mirror_Texture;


    protected override void Awake()
    {
        base.Awake();
        renderTexture = new RenderTexture(256,256,0);
        mirrorCam.targetTexture = renderTexture;
        mirror_Texture.texture = renderTexture;
    }
}
