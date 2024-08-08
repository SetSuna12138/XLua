using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEditor;
using UnityEngine;

///<summary>
///创建版本文件
///</summary>
public class CreateABCompare
{
    [MenuItem("CreateFile/CreateABCompareFile")]
    public static void CreateABCompareFile()
    {
        string path = Path.Combine(Application.dataPath, "AssetBundlesFile", "PC/");
        DirectoryInfo directory = Directory.CreateDirectory(path);

        FileInfo[] fileInfos = directory.GetFiles();
        string abCompare = "";
        foreach (FileInfo file in fileInfos)
        {
            if(file.Extension == "")
            {
                abCompare += file.Name + " " + file.Length + " " + GetMD5(file.FullName);
                abCompare += "|";
            }
            //Debug.Log("" + file.Name);文件名
            //Debug.Log("" + file.FullName);文件路径
            //Debug.Log("" + file.Extension);文件后缀
            //Debug.Log("" + file.Length);文件大小
        }
        abCompare = abCompare.Substring(0, abCompare.Length - 1);
        Debug.Log(abCompare);

        File.WriteAllText(path + "ABCompareIndo.txt", abCompare);
    }

    private static string GetMD5(string filePath)
    {
        using (FileStream file = new FileStream(filePath, FileMode.Open))
        {

            //生成一个MD5对象，用于生成MD5码
            MD5 md5 = new MD5CryptoServiceProvider();

            //利用MD5API，得到数据的MD5码 16个字节数组
            byte[] md5Info = md5.ComputeHash(file);

            //关闭文件流
            file.Close();

            StringBuilder sb = new StringBuilder();
            foreach (byte b in md5Info)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

    }
}
