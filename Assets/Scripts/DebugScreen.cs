using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScreen : MonoBehaviour
{
    private World world;
    private Text text;

    private float frameRate;
    private float timer;

    private int halfWordSizeInVoxels;
    public int HalfWordSizeInChunks;

    void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();
        text = GetComponent<Text>();

        halfWordSizeInVoxels = VoxelData.WorldSizeInVoxels / 2;
        HalfWordSizeInChunks = VoxelData.WorldSizeInChunks / 2;
    }
    
    void Update()
    {
        string debugText = "OurCraft, by arian";
        debugText += "\n";
        debugText += frameRate + " fps";
        debugText += "\n\n";
        debugText += "XYZ: " + (Mathf.FloorToInt(world.player.transform.position.x) - halfWordSizeInVoxels) + " / " + 
                     Mathf.FloorToInt(world.player.transform.position.y) + " / " + (Mathf.FloorToInt(world.player.transform.position.z)- halfWordSizeInVoxels);
        debugText += "\n";
        debugText += "Chunk: " + (world.playerChunkCoord.x - HalfWordSizeInChunks) + " / " + (world.playerChunkCoord.z - HalfWordSizeInChunks);

        text.text = debugText;

        if (timer > 1f)
        {

            frameRate = (int) (1f / Time.unscaledDeltaTime);
            timer = 0;

        }
        else
            timer += Time.deltaTime;
    }
}
