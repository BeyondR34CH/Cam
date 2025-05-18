using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamController : MonoBehaviour
{
    public int initCamIndex;
    public RawImage display;
    public Text buttonText;

    private int currentCamIndex;
    private WebCamTexture camTex;

    public void CamSwitch()
    {
        if (WebCamTexture.devices.Length == 0)
        {
            buttonText.text = "������ͷ啊啊啊";
        }
        else
        {
            string camName = WebCamTexture.devices[currentCamIndex].name;
            camTex = new WebCamTexture(camName);
            display.texture = camTex;

            camTex.Play();
            buttonText.text = ++currentCamIndex + "." + camName;

            currentCamIndex %= WebCamTexture.devices.Length;
        }
    }

    private void Awake()
    {
        if (WebCamTexture.devices.Length > initCamIndex)
        {
            currentCamIndex = initCamIndex;
            CamSwitch();
        }
        else
        {
            currentCamIndex = 0;
            buttonText.text = "������ͷ";
        }
    }
}
