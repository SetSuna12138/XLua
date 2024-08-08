using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEditor;
using UnityEngine;

///<summary>
///�����汾�ļ�
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
            //Debug.Log("" + file.Name);�ļ���
            //Debug.Log("" + file.FullName);�ļ�·��
            //Debug.Log("" + file.Extension);�ļ���׺
            //Debug.Log("" + file.Length);�ļ���С
        }
        abCompare = abCompare.Substring(0, abCompare.Length - 1);
        Debug.Log(abCompare);

        File.WriteAllText(path + "ABCompareIndo.txt", abCompare);
    }

    private static string GetMD5(string filePath)
    {
        using (FileStream file = new FileStream(filePath, FileMode.Open))
        {

            //����һ��MD5������������MD5��
            MD5 md5 = new MD5CryptoServiceProvider();

            //����MD5API���õ����ݵ�MD5�� 16���ֽ�����
            byte[] md5Info = md5.ComputeHash(file);

            //�ر��ļ���
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
