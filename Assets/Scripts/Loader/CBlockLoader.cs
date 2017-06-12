using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBlockLoader : CResourceLoader {

    public struct BlockPaths
    {
        public string PathPink;
        public string PathBlue;
        public string PathYellow;
        public string PathGreen;
        public string PathGray;
        public string PathWall;
        public string PathVerticalBomb;
        public string PathHorizontalBomb;
        public string PathFiveBomb;
    }

    private BlockPaths InitBlockPaths()
    {
        BlockPaths paths = new BlockPaths();

        paths.PathPink = "Prefabs/Block/PFPink";
        paths.PathBlue = "Prefabs/Block/PFBlue";
        paths.PathYellow = "Prefabs/Block/PFYellow";
        paths.PathGreen = "Prefabs/Block/PFGreen";
        paths.PathGray = "Prefabs/Block/PFGray";
        paths.PathWall = "Prefabs/Block/PFWall";
        paths.PathVerticalBomb = "Prefabs/Block/PFVerticalBomb";
        paths.PathHorizontalBomb = "Prefabs/Block/PFHorizontalBomb";
        paths.PathFiveBomb = "Prefabs/Block/PFFiveBomb";

        return paths;
    }

    private CBlock PFPink = null;
    private CBlock PFBlue = null;
    private CBlock PFYellow = null;
    private CBlock PFGreen= null;
    private CBlock PFGray = null;
    private CBlock PFWall = null;
    private CBlock PFVerticalBomb = null;
    private CBlock PFHorizontalBomb = null;
    private CBlock PFFiveBomb = null;



    public Dictionary<CMap.Kind, CBlock> BlockKind = null;


    public override void Load()
    {
        BlockPaths paths = InitBlockPaths();

        PFPink = Resources.Load<CBlock>(paths.PathPink);
        PFBlue = Resources.Load<CBlock>(paths.PathBlue);
        PFYellow = Resources.Load<CBlock>(paths.PathYellow);
        PFGreen = Resources.Load<CBlock>(paths.PathGreen);
        PFGray = Resources.Load<CBlock>(paths.PathGray);
        PFWall = Resources.Load<CBlock>(paths.PathWall);
        PFVerticalBomb = Resources.Load<CBlock>(paths.PathVerticalBomb);
        PFHorizontalBomb = Resources.Load<CBlock>(paths.PathHorizontalBomb);
        PFFiveBomb = Resources.Load<CBlock>(paths.PathFiveBomb);

        BlockKind = new Dictionary<CMap.Kind, CBlock>();

        BlockKind.Add(CMap.Kind.Blue, PFBlue);
        BlockKind.Add(CMap.Kind.Gray, PFGray);
        BlockKind.Add(CMap.Kind.Green, PFGreen);
        BlockKind.Add(CMap.Kind.Pink, PFPink);
        BlockKind.Add(CMap.Kind.Wall, PFWall);
        BlockKind.Add(CMap.Kind.Yellow, PFYellow);
        BlockKind.Add(CMap.Kind.VerticalBomb, PFVerticalBomb);
        BlockKind.Add(CMap.Kind.HorizontalBomb, PFHorizontalBomb);
        BlockKind.Add(CMap.Kind.FiveBomb, PFFiveBomb);
    }

    public CBlock GetPrefab(CMap.Kind tKind)
    {
        if(BlockKind.ContainsKey(tKind))
        {
           // Debug.Log("GetPrefab?");
            return BlockKind[tKind];
        }
        Debug.Log("GetPrefab is Null");
        return null;
    }
}
