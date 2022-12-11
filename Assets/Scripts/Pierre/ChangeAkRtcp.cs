using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.UI;

public class ChangeAkRtcp : MonoBehaviour
{
    public AK.Wwise.RTPC rtcp;
    public void setRtcp(Slider _slider)
    {
        rtcp.SetGlobalValue(_slider.value);
    }
}
