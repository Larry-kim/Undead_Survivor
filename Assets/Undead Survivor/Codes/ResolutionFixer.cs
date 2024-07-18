using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionFixer : MonoBehaviour
{
    void Start()
    {
        int width = Screen.width;
        int height = Screen.height;

        // Ȧ�� �ػ��� ��� ¦���� ����
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
