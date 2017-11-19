using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockType
{
    Empty,
    LeftWall,
    RightWall,
    LeftCorner,
    RightCorner,
    Hall
}

public class GameManager : MonoBehaviour {

    public Block blockPrefab;

    public int blockSize = 4;

	// Use this for initialization
	void Start () {
        Block leftBlock = Instantiate(blockPrefab, Vector3.right * -blockSize, Quaternion.identity, transform);
        leftBlock.SetBlockType(BlockType.LeftCorner);
        Block centerblock = Instantiate(blockPrefab, transform);
        Block rightBlock = Instantiate(blockPrefab, Vector3.right * blockSize, Quaternion.identity, transform);
        rightBlock.SetBlockType(BlockType.RightWall, true);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
