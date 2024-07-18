using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionFixer : MonoBehaviour
{
    void Start()
    {
        int width = Screen.width;
        int height = Screen.height;

        // 홀수 해상도일 경우 짝수로 변경
        if (width % 2 != 0)
        {
            width += 1;
        }

        if (height % 2 != 0)
        {
            height -= 1;
        }

        Screen.SetResolution(width, height, Screen.fullScreen);
    }
}
