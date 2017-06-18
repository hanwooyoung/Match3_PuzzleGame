using UnityEngine;

public class CPlayerPrefsInt
{
    public int Value
    {
        get
        {
            return PlayerPrefs.GetInt(mKey, 0);
        }
        set
        {
            PlayerPrefs.SetInt(mKey, value);
            PlayerPrefs.Save();
        }
    }
    private string mKey = "";


    public CPlayerPrefsInt(string key, int value = 0)
    {
        mKey = key;
        if (PlayerPrefs.HasKey(key) == false)
        {
            PlayerPrefs.SetInt(mKey, value);
        }
    }
}

