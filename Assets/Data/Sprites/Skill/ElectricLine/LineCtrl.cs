using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCtrl : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] List<Texture> textures;
    private int animationStep;
    [SerializeField] float fps = 30f;
    private float fpsCounter;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        fpsCounter +=Time.deltaTime;
        if (fpsCounter >= 1f / fps)
        {
            animationStep++;
            if (animationStep == textures.Count)
                animationStep = 0;
            lineRenderer.material.SetTexture("_MainTex",textures[animationStep]);
            fpsCounter = 0;
        }
    }
}
