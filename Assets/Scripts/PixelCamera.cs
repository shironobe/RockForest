using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
public class PixelCamera : MonoBehaviour
{
     PixelPerfectCamera PixelCam;

    [SerializeField] int ppu;
    void Start()
    {
        PixelCam = GetComponent<PixelPerfectCamera>();
        PixelCam.assetsPPU =ppu;
        PixelCam.upscaleRT = false;
    }

    // Update is called once per frame
  
}
