using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using XLua;
using XLua.LuaDLL;

[Hotfix]
class LuaToCSharp : MonoBehaviour
{
    
    private delegate int Add(int a, int b, out string res2, out bool res3);
    LuaEnv luaEnv;

    void Start()
    {
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(Myloader);
        luaEnv.DoString("require 'LuaTest'");

        //var p = luaEnv.Global.Get<Dictionary<string, object>>("person");
        //foreach (var k in p)
        //{
        //    Debug.Log($"key:{k.Key} Value:{k.Value}");
        //}

        //var person2 = luaEnv.Global.Get<List<object>>("person");
        //foreach (var k in person2)
        //{
        //    Debug.Log(k);
        //}

        //var add = luaEnv.Global.Get<Action<int, int>>("add");
        //add(1,3);
        //add = null;
        //luaEnv.Dispose();

       // int res1 = add(12, 3, out string res2, out bool red3);
       
        //StartCoroutine(DisposeLuaEnv(luaEnv));
    }

    private byte[] Myloader(ref string filePath)
    {
        string path = Application.dataPath + "/BuildResources/Lua/" + filePath + ".lua.txt";

        return Encoding.UTF8.GetBytes(File.ReadAllText(path));
    }

    IEnumerator DisposeLuaEnv(LuaEnv luaEnv)
    {
        yield return new WaitForSeconds(0.1f);
        luaEnv.Dispose();
    }

}

[CSharpCallLua]
public interface IPerson
{
    string name { get; set; }
    int age { get; set; }
    void eat();
    void add(int a, int b);
}

class Person
{
    public string name;
    public int age;
    public void eat() { }
    public void add(int a, int b) { }
}

