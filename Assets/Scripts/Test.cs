using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class Test : MonoBehaviour
{
    private IEnumerator Start()
    {
        AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(Application.streamingAssetsPath + "/ui/prefab/image.prefab.ab");
        yield return request;

        AssetBundleCreateRequest requestImage = AssetBundle.LoadFromFileAsync(Application.streamingAssetsPath + "/ui/res/1.png.ab");
        yield return requestImage;

        AssetBundleRequest bundle = request.assetBundle.LoadAssetAsync("Assets/BuildResources/UI/Prefab/Image.prefab");
        yield return bundle;

        GameObject go = Instantiate(bundle.asset) as GameObject;
        go.transform.SetParent(this.transform);
        go.SetActive(true);
        go.transform.localPosition = Vector3.zero;
    }
}
