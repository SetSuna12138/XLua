using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Ŀ¼��
///</summary>
public static class PathUtil
{
    //��Ŀ¼
    public static readonly string AssetsPath = Application.dataPath;

    //��Ҫ��bundle��Ŀ¼
    public static readonly string BuildResourcesPath = AssetsPath + "/BuildResources/";

    //bundle ���Ŀ¼
    public static readonly string BuildOutPath = Application.streamingAssetsPath;

    //ֻ��Ŀ¼
    public static readonly string readPath = Application.streamingAssetsPath;

    //��дĿ¼
    public static readonly string readWritePath = Application.persistentDataPath;

    public static string GetUnityPath(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return string.Empty;
        }
        return path.Substring(path.IndexOf("Assets"));
    }

    public static string GetStanderPath(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return string.Empty;
        }
        return path.Trim().Replace("\\", "/");
    }
}
