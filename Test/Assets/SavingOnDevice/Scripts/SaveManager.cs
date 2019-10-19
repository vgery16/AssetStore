using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    /// <summary>
    /// This has the JSon array of every asset (in this case JSon of PlayerData)
    /// </summary>
    [SerializeField]
    private StringHolder Saving = new StringHolder();

    /// <summary>
    /// Every Asset I want to Save in this case it is PlayerData
    /// </summary>
    public SavableAssets[] SavableAssetArray;

    /// <summary>
    /// Main JSon string what is saved to Binary File
    /// </summary>
    private string JSon = "";

    /// <summary>
    /// Call This to load all asset Data
    /// </summary>
    public void LoadAssets()
    {
        // Load data
        LoadFile();

        if (Saving.List.Count <= 0) return;
        for (int i = 0; i < SavableAssetArray.Length; i++)
        {
            SavableAssetArray[i].Load(Saving.GetJSonFromKey(SavableAssetArray[i].name));
        }
    }

    /// <summary>
    /// Call this to save all assets JSon data
    /// </summary>
    public void SaveAssets()
    {
        foreach (var asset in SavableAssetArray)
        {
            if(Saving.ContainsKey(asset.name))
            {
                // save data value to its key
                Saving.SaveData(asset.name,asset.Save());
            }
            else
            {
                // If the key is not set yet then add it with its values
                Saving.List.Add(new StringHolder.KeyValuePair(asset.name, asset.Save()));
            }
        }
        // Create Json
        JSon = JsonUtility.ToJson(Saving);
        SaveProgress(JSon);
    }

    /// <summary>
    /// Saving to PlayerSave.dat in binary format (it is harder to modify then saving it to text file)
    /// </summary>
    /// <param name="JSon"></param>
    private void SaveProgress(string JSon)
    {
        // C:\Users\YourPcName\AppData\LocalLow\DefaultCompany\ProjectName
        string destination = Application.persistentDataPath + "/PlayerSave.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);
        
        BinaryFormatter bf = new BinaryFormatter();
        Debug.Log("Saving ---> "+ JSon);
        bf.Serialize(file, JSon);
        file.Close();
    }

    /// <summary>
    /// Load JSons from PlayerSave.dat file 
    /// </summary>
    private void LoadFile()
    {
        string destination = Application.persistentDataPath + "/PlayerSave.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        string Json = (string) bf.Deserialize(file);
        Debug.Log("Loading ---> " + Json);
        file.Close();
        Saving = JsonUtility.FromJson(Json, typeof(StringHolder)) as StringHolder;
    }

}
