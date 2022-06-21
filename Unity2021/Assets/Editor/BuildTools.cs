using UnityEditor;
using UnityEngine;
using System.IO;
using System.Diagnostics;
using UnityEngine.UI;
using System.Text;
using System.Collections.Generic;


class BuildTools
{
    [MenuItem("BuildTools/Build Asset Bundle", false, 300)]
    static void BuildAssetBundle()
    {
        BuildAssetBundles();
    }

    static void BuildAssetBundles()
    {
        var resourcePath = GetBuildRoot();
        if (Directory.Exists(resourcePath))
        {
            Directory.Delete(resourcePath, true);
        }
        Directory.CreateDirectory(resourcePath);
        BuildPipeline.BuildAssetBundles(resourcePath,
            BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);

    }
    static string GetBuildRoot()
    {
        //return Path.Combine(System.Environment.CurrentDirectory, "BuildAssets","test");
        return Path.Combine(System.Environment.CurrentDirectory, "Assets", "StreamingAssets", "test");
    }
}
