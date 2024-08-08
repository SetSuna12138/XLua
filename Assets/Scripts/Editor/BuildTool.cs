using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

///<summary>
///打包
///</summary>
public class BuildTool : Editor
{
    #region 选择平台
    [MenuItem("Tools/Build Windows Bundle")]
    static void BundleWindowsBuild()
    {
        Build(BuildTarget.StandaloneWindows);
    }

    [MenuItem("Tools/Build Android Bundle")]
    static void BundleAndroidBuild()
    {
        Build(BuildTarget.Android);
    }

    [MenuItem("Tools/Build iPhone Bundle")]
    static void BundleiPhoneBuild()
    {
        Build(BuildTarget.iOS);
    }
    #endregion

    [MenuItem("Tools/Delete")]
    static void Dele()
    {
        if(Directory.Exists(PathUtil.BuildOutPath))
            Directory.Delete(PathUtil.BuildOutPath, true);  
    }

    static void Build(BuildTarget target)
    {

        string[] files = Directory.GetFiles(PathUtil.BuildResourcesPath, "*", SearchOption.AllDirectories);

        List<AssetBundleBuild> assetBundleBuilds = new List<AssetBundleBuild>();
        AssetBundleBuild assetBundle = new AssetBundleBuild();

        for (int i = 0; i < files.Length; i++)
        {
            if (files[i].EndsWith(".meta"))
                continue;
            
            string fileName = PathUtil.GetStanderPath(files[i]);
            Debug.Log("files : " + fileName);

            string assetName = PathUtil.GetUnityPath(files[i]);
            assetBundle.assetNames = new string[] { assetName };

            string bundleName = files[i].Replace(PathUtil.BuildResourcesPath, "").ToLower();
            assetBundle.assetBundleName = bundleName + ".ab";

            assetBundleBuilds.Add(assetBundle);
        }

        CreateFiles();

        BuildAssetBundleOptions options = BuildAssetBundleOptions.None;

        AssetBundleManifest man = BuildPipeline.BuildAssetBundles(
            PathUtil.BuildOutPath,
            assetBundleBuilds.ToArray(),
            options,
            target
        );


    }

    private static void CreateFiles()
    {
        if (!Directory.Exists(PathUtil.BuildOutPath))
        {
            Directory.CreateDirectory(PathUtil.BuildOutPath);
        }
    }
}
