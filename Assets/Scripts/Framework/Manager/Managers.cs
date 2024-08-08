using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class Managers : MonoBehaviour
{
    private static LuaManager _lua;
    public static LuaManager Lua
    {
        get { return _lua; }
    }

    private void Awake()
    {
        _lua = this.gameObject.AddComponent<LuaManager>();
    }

}
