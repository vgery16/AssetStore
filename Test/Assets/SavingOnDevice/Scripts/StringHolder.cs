using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StringHolder
{

    [System.Serializable]
    public class KeyValuePair
    {
        // Name of the Asset
        public string Key;
        // JSon of the Asset
        public string Value;
        // constructor
        public KeyValuePair(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
    /// <summary>
    /// List containing all savable JSons
    /// </summary>
    [SerializeField]
    public List<KeyValuePair> List = new List<KeyValuePair>();

    /// <summary>
    /// Iterates through all Saved JSons and check the keys to find the right one
    /// </summary>
    /// <param name="key"> Key - Value Pair</param>
    /// <returns> It returns the Value of a specific key </returns>
    public string GetJSonFromKey(string key)
    {
        foreach (var save in List)
        {
            if (save.Key.Equals(key)) return save.Value;
        }
        return string.Empty;
    }

    /// <summary>
    /// Checking if Our savable List contains key or not
    /// </summary>
    /// <param name="key"> the assets name </param>
    /// <returns> true if our list alredy contains our key </returns>
    public bool ContainsKey(string key)
    {
        foreach (var save in List)
        {
            if (save.Key.Equals(key)) return true;
        }
        return false;
    }

    /// <summary>
    /// Saving (updating) value if the key alredy exist 
    /// </summary>
    /// <param name="key"> this key alredy exist in the List </param>
    /// <param name="JSon"> we want to update the Json with this </param>
    public void SaveData(string key, string JSon)
    {
        foreach (var save in List)
        {
            if (save.Key.Equals(key))
            {
                save.Value = JSon;
                break;
            }
        }
    }
}
