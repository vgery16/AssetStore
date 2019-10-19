using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Every ScriptableObject which has savable data (like PlayerDatas health) should be derived from SavableAssets
/// </summary>
public abstract class SavableAssets: ScriptableObject {

    // to Save Data
    public abstract string Save();

    // to Load Data
    public abstract void Load(string JSON);

}
