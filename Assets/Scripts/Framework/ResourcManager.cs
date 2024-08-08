using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

///<summary>
///���ر�����Դ
///</summary>
public class ResourcManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Asyncotor());
    }
    /// <summary>
    /// �첽����������
    /// </summary>
    /// <returns></returns>
    IEnumerator Asyncotor()
    {
        string assetBundleDirectory = Application.streamingAssetsPath;
        string manifestPath = Path.Combine(assetBundleDirectory, "StandaloneWindows64");

        //��������
        AssetBundle manifestBundle = AssetBundle.LoadFromFile(manifestPath);
        AssetBundleManifest manifest = manifestBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

        string[] dependencies = manifest.GetAllDependencies("prefab");
        foreach (string dependency in dependencies)
        {
            string dependencyPath = Path.Combine(assetBundleDirectory, dependency);
            AssetBundle.LoadFromFile(dependencyPath);
        }

        //���ذ�
        string bundlePath = Path.Combine(assetBundleDirectory, "prefab");
        AssetBundleCreateRequest bundleRequest = AssetBundle.LoadFromFileAsync(bundlePath);
        yield return bundleRequest;

        AssetBundle myLoadAssetBundle = bundleRequest.assetBundle;
        if (myLoadAssetBundle == null)
        {
            Debug.LogError("�հ������ڹ���ֹ����");
            yield break;
        }

        //������Դ
        AssetBundleRequest assetRequest = myLoadAssetBundle.LoadAssetAsync<GameObject>("Assets/BuildResources/UI/Prefab/Image");
        yield return assetRequest;

        Object obj = Instantiate(assetRequest.asset);
        GameObject prefab = obj as GameObject;
        if (prefab != null)
        {
            prefab.transform.SetParent(this.transform);
            prefab.SetActive(true);
            prefab.transform.localPosition = Vector3.zero;
        }

        myLoadAssetBundle.Unload(false);
        manifestBundle.Unload(false);
    }


    /// <summary>
    /// �첽����������
    /// </summary>
    /// <returns></returns>
    IEnumerator Async()
    {
        AssetBundleCreateRequest bundleRequest = AssetBundle.LoadFromFileAsync(Application.streamingAssetsPath + "/prefab");
        yield return bundleRequest;

        AssetBundle myLoad = bundleRequest.assetBundle;
        if (myLoad == null)
        {
            Debug.LogError("���ǿյģ����ڹ���ֹ����");
            yield break;
        }

        //���ذ�����Դ
        AssetBundleRequest assetRequest = myLoad.LoadAssetAsync<GameObject>("Assets/BuildResources/UI/Prefab/Image.prefab");
        yield return assetRequest;

        Object obj = Instantiate(assetRequest.asset);
        GameObject prefab = obj as GameObject;
        if (prefab != null)
        {
            prefab.transform.SetParent(this.transform);
            prefab.SetActive(true);
            prefab.transform.localPosition = Vector3.zero;
        }

        //myLoad.Unload(false);
    }

    /// <summary>
    /// ͬ������
    /// </summary>
    /// <param name="str"></param>
    void Sync(string str)
    {
        AssetBundle bundle = AssetBundle.LoadFromFile(str);
        if (bundle != null)
        {
            Debug.LogError("AssetBundle Null");
            return;
        }


        GameObject go = bundle.LoadAsset<GameObject>(str);
        if (go != null)
        {
            Instantiate(go);
            go.SetActive(true);
        }

        bundle.Unload(false);
    }
}
