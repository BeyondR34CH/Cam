using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayController : MonoBehaviour
{
    public int camIndex;
    public RawImage display;

    private WebCamTexture camTex;

    public void CamSwitch()
    {
        camTex = new WebCamTexture(WebCamTexture.devices[camIndex].name);
        display.texture = camTex;
        camTex.Play();
    }

    private void Awake()
    {
        if (WebCamTexture.devices.Length > camIndex) CamSwitch();
    }

    private void OnDisable()
    {
        camTex.Stop();
    }
}
