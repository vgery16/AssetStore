using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// We want to save this Data
/// </summary>
[CreateAssetMenu(fileName = "PlayerData", menuName = "Create Player Data")]
public class PlayerData : SavableAssets
{
    /// <summary>
    /// Health of the Player (just an example value to save)
    /// </summary>
    public float Health;

    /// <summary>
    /// Loading this means override this ScriptableObject from JSON 
    /// </summary>
    /// <param name="JSON"></param>
    public override void Load(string JSON)
    {
        JsonUtility.FromJsonOverwrite(JSON, this);
    }

    /// <summary>
    /// Saving means doing JSon from this and returning it to SaveManager
    /// </summary>
    public override string Save()
    {
        return JsonUtility.ToJson(this);
    }

}
