﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GvrUsLog : MonoBehaviour
{
    string user_log;
    string log_path;

    // Use this for initialization
    void Start()
    {
        user_log = System.DateTime.Now.ToString("yyyy-MM-dd, hh:mm:ss") + "\n" + System.Environment.UserName + " : " + SystemInfo.deviceName + " (" + SystemInfo.deviceUniqueIdentifier + ")\n"
            + SystemInfo.operatingSystem + "\n" + SystemInfo.processorCount + " " + SystemInfo.processorType + ", " + SystemInfo.systemMemorySize + "MB\n" + SystemInfo.graphicsDeviceName + "\n\n"; ;

#if UNITY_EDITOR
		log_path = Path.Combine(Application.dataPath + "/GoogleVR/Editor", "user_log.log");
        Debug.Log(log_path);

#elif UNITY_IOS
		log_path = Path.Combine(Application.temporaryCachePath + "/Raw", "user_log.json");

#elif UNITY_ANDROID
		log_path = Path.Combine(Application.temporaryCachePath, "user_log.json");
#endif

        FileStream file = new FileStream(log_path, FileMode.Append, FileAccess.Write);
        file.Flush();
        StreamWriter sw = new StreamWriter(file);
        sw.Write(user_log);

        sw.Close();
        file.Close();
    }
}