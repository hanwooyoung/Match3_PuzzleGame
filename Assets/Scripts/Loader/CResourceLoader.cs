using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CResourceLoader
{
    public abstract void Load();

    protected virtual void PrefabLoad<T>( T tVariable,string tPath) where T : MonoBehaviour
    {
        if(tVariable == null)
        {
            tVariable = Resources.Load<T>(tPath);
        }
    }
}
