using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using XLua;

namespace Lua
{
    [Hotfix]
    class Hotfix_Test : MonoBehaviour
    {
        public LuaEnv luaEnv;

        private void Start()
        {
            luaEnv = new LuaEnv();
            luaEnv.DoString("CS.UnityEngine.Debug.Log('Hello World')");
            Debug.Log("Unity_Hello World");
            luaEnv.Dispose();
        }

    }
}
