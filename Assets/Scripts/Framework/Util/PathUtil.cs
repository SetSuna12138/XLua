using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///目录集
///</summary>
public static class PathUtil
{
    //根目录
    public static readonly string AssetsPath = Application.dataPath;

    //需要打bundle的目录
    public static readonly string BuildResourcesPath = AssetsPath + "/BuildResources/";

    //bundle 输出目录
    public static readonly string BuildOutPath = Application.streamingAssetsPath;

    //只读目录
    public static readonly string readPath = Application.streamingAssetsPath;

    //读写目录
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
