using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    BlockType blockType;
    bool pit = false;

    int height = 4;
    int size = 4;

    public Transform groundPrefab;
    public Transform wallPrefab;
    public Transform pillarPrefab;

    // Use this for initialization
    void Start () {
        CreateBlock();
    }

    // Update is called once per frame
    void Update () {
		
	}


    void CreateBlock()
    {
        Debug.Log(blockType);
        switch(blockType)
        {
            case BlockType.LeftWall:
                CreateLeftWall();
                break;
            case BlockType.RightWall:
                CreateRightWall();
                break;
            case BlockType.LeftCorner:
                CreateLeftCorner();
                break;
            case BlockType.RightCorner:
                CreateRightCorner();
                break;
            case BlockType.Hall:
                CreateHall();
                break;
            default:
                break;
        }

        CreateCeiling();
        if(!pit)
        {
            CreateGround();
        }
    }


    public void SetBlockType()
    {
        blockType = BlockType.Empty;
    }

    public void SetBlockType(BlockType type)
    {
        switch(type)
        {
            case BlockType.LeftWall:
                blockType = BlockType.LeftWall;
                break;
            case BlockType.RightWall:
                blockType = BlockType.RightWall;
                break;
            case BlockType.LeftCorner:
                blockType = BlockType.LeftCorner;
                break;
            case BlockType.RightCorner:
                blockType = BlockType.RightCorner;
                break;
            case BlockType.Hall:
                blockType = BlockType.Hall;
                break;
            default:
                SetBlockType();
                break;
        }
    }

    public void SetBlockType(BlockType type, bool pit)
    {
        this.pit = pit;
        SetBlockType(type);
    }

    public void SetBlockType(bool pit)
    {
        this.pit = pit;
        SetBlockType();
    }

    public void SetBlockSize(int size)
    {
        this.size = size;
    }


    void CreateLeftCorner()
    {
        CreateSideWall();
        CreateWall();
    }

    void CreateRightCorner()
    {
        CreateSideWall(false);
        CreateWall();
    }

    void CreateLeftWall()
    {
        CreateSideWall();
    }

    void CreateRightWall()
    {
        CreateSideWall(false);
    }

    void CreateHall()
    {
        CreateSideWall();
        CreateSideWall(false);
    }
    
    void CreateWall()
    {
        Transform wall = Instantiate(wallPrefab, transform);
        wall.localScale = new Vector3(wall.localScale.x, height, size);
        wall.localPosition = Vector3.forward * size * 0.5f;
        wall.localRotation = Quaternion.Euler(0, 90, 0);
    }

    void CreateSideWall(bool left)
    {
        Transform wall = Instantiate(wallPrefab, transform);
        wall.localScale = new Vector3(wall.localScale.x, height, size);

        if (left)
        {
            wall.localPosition = Vector3.right * -size * 0.5f;
        } else
        {
            wall.localPosition = Vector3.right * size * 0.5f;
        }
    }

    void CreateSideWall()
    {
        CreateSideWall(true);
    }

    void CreateGround()
    {
        Transform ground = Instantiate(groundPrefab, transform);
        ground.localScale = new Vector3(size, ground.localScale.y, size);
        ground.localPosition = Vector3.up * -height * 0.5f;
    }

    void CreateCeiling()
    {
        Transform ceiling = Instantiate(groundPrefab, transform);
        ceiling.localScale = new Vector3(size, ceiling.localScale.y, size);
        ceiling.localPosition = Vector3.up * height * 0.5f;
    }
}
