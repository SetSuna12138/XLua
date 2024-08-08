using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using XLua;

namespace Manager
{
    class ABManager
    {

        IEnumerator DownloadMD5File(string downUrl)
        {
            UnityWebRequest request = UnityWebRequest.Get(downUrl);
            yield return request;

            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
        }

        

    }
}
