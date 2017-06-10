using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CUserData
{
    private CPlayerPrefsInt mCoin = null;
    public int Coin
    {
        get
        {
            return mCoin.Value;
        }
        set
        {
            mCoin.Value = value;
        }
    }

    private CPlayerPrefsInt mHeart = null;
    public int Heart
    {
        get
        {
            return mHeart.Value;
        }
        set
        {
            mHeart.Value = value;
        }
    }

    private CPlayerPrefsInt mExitTime = null;
    public int ExitTime
    {
        get
        {
            return mExitTime.Value;
        }
        set
        {
            mExitTime.Value = value;
        }
    }

    private CPlayerPrefsInt mSpareTime = null;
    public int SpareTime
    {
        get
        {
            return mSpareTime.Value;
        }
        set
        {
            mSpareTime.Value = value;
        }
    }

    private CPlayerPrefsInt mItem1 = null;
    public int Item1
    {
        get
        {
            return mItem1.Value;
        }
        set
        {
            mItem1.Value = value;
        }
    }

    private CPlayerPrefsInt mItem2 = null;
    public int Item2
    {
        get
        {
            return mItem2.Value;
        }
        set
        {
            mItem2.Value = value;
        }
    }

    private CPlayerPrefsInt mItem3 = null;
    public int Item3
    {
        get
        {
            return mItem3.Value;
        }
        set
        {
            mItem3.Value = value;
        }
    }

    private CPlayerPrefsInt mItem4 = null;
    public int Item4
    {
        get
        {
            return mItem4.Value;
        }
        set
        {
            mItem4.Value = value;
        }
    }

    public CUserData()
    {
        mCoin = new CPlayerPrefsInt("UserCoin");
        mHeart = new CPlayerPrefsInt("UserHeart");
        mExitTime = new CPlayerPrefsInt("ExitTime");
        mSpareTime = new CPlayerPrefsInt("SpareTime");
        mItem1 = new CPlayerPrefsInt("Item1");
        mItem2 = new CPlayerPrefsInt("Item2");
        mItem3 = new CPlayerPrefsInt("Item3");
        mItem4 = new CPlayerPrefsInt("Item4");

    }
}
