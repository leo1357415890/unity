using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainApp : MonoBehaviour
{
    private bool isAbMode = true;

    private void Awake()
    {
        Debug.Log("Main.Awake");

    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Main.Start");
        string[] abpath = { "/test/test_fbx.ab", "/test/test_mat.ab", "/test/test_tex.ab", "/test/test_prefab.ab", "/test/test_prefab1.ab" };
        if (isAbMode)
        {
            Dictionary<string, AssetBundle> ab = new Dictionary<string, AssetBundle>();
            foreach (string path in abpath)
            {
                var a = AssetBundle.LoadFromFile(Application.streamingAssetsPath + path);
                ab[path] = a;
            }
            //var prefabPath = "Assets/Eff/AEffectTest/prefab/dao_effect2.prefab";
            GameObject asset = ab[abpath[3]].LoadAsset<GameObject>("dao_effect2");
            GameObject go = GameObject.Instantiate(asset, GameObject.Find("Canvas").transform);
        }
        else
        {
            //string[] abpath0 = { "/test/test_fbx.ab", "/test/test_mat.ab", "/test/test_tex.ab", "/test/test_prefab.ab" };
#if UNITY_EDITOR
            string[] abpath1 = UnityEditor.AssetDatabase.GetAssetPathsFromAssetBundle("test_prefab1.ab");
            foreach (string assetPath in abpath1)
            {
                if (assetPath.Contains("dao_effect3"))
                {
                    GameObject asset = UnityEditor.AssetDatabase.LoadAssetAtPath<UnityEngine.GameObject>(assetPath);
                    GameObject go = GameObject.Instantiate(asset, GameObject.Find("Canvas").transform);
                    break;
                }
            }
#endif
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
