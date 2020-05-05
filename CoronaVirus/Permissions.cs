using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class Permissions : MonoBehaviour
{
    GameObject dialog = null;
    int flag = 0;
    void Update()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera) && flag == 0)
        {
            Permission.RequestUserPermission(Permission.Camera);
        }
        else { flag = 1; }
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone) && flag == 1)
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
        else { flag = 2; }
#endif
    }

    
}
