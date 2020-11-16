using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class World : MonoBehaviour
{
    internal PrefabCollection prefabList;

    List<FarmPatch> world = new List<FarmPatch>();

    private int patchSize = 2;

    List<ConstructionPatch> currentConstructionPatches = new List<ConstructionPatch>();

    // Start is called before the first frame update
    void Start() 
    {
        prefabList = GameObject.FindGameObjectWithTag("PREFAB_LIST").GetComponent<PrefabCollection>();

        InitStartWorld();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void InitStartWorld()
    {
        // cross of starting => this is what every world will look like when it starts
        CreateNewFarmPatchAt(0, 0);
        CreateNewFarmPatchAt(-2, 0);
        CreateNewFarmPatchAt(2, 0);
        CreateNewFarmPatchAt(0, -2);
        CreateNewFarmPatchAt(0, 2);

        PlantAt(Plantables.Tree, 0, 0);
    }

    private void PlantAt(Plantables plant, int x, int y)
    {
        // get farm patch at postion
        FarmPatch patch = world.Where(worldItem => worldItem.WorldPositionX == x && worldItem.WorldPositionY == y).FirstOrDefault();

        if(patch != null)
        {
            // plant something there
            patch.Plant(plant);
        }
    }

    public void CreateNewFarmPatchAt(int x, int y)
    {
        // create prefab
        GameObject patch = Instantiate(prefabList.farmPatchPrefab, new Vector3(x, 0, y), Quaternion.identity);
        // init prefab with world ref
        patch.GetComponent<FarmPatch>().Initialize(x, y, this.gameObject);
        // add FarmPatch component to the world List<FarmPatch> if needed access the overaying gameobject with FarmPatch.gameObject (thanks to MonoBehaviour)
        world.Add(patch.GetComponent<FarmPatch>());
    }

    private void CreateConstructionPatchAt(int x, int y)
    {
        // create prefab
        GameObject patch = Instantiate(prefabList.constructionPatchPrefab, new Vector3(x, 0, y), Quaternion.identity);
        // init prefab with world ref
        patch.GetComponent<ConstructionPatch>().Initialize(x, y, this.gameObject);
        currentConstructionPatches.Add(patch.GetComponent<ConstructionPatch>());
    }

    public void EnableEditMode()
    {
        // look for patches that can be build upon


        // get patch position
        // check for neighbours
        // if no neighbour exists
        // create construction patch

        foreach(FarmPatch farmPatchItem in world)
        {
            int leftX = farmPatchItem.WorldPositionX - patchSize;
            int rightX = farmPatchItem.WorldPositionX + patchSize;

            int upY = farmPatchItem.WorldPositionY - patchSize;
            int downY = farmPatchItem.WorldPositionY + patchSize;


            // check every corner

            // left patch
            if (IsPatchPositionFree(leftX, farmPatchItem.WorldPositionY))
            {
                CreateConstructionPatchAt(leftX, farmPatchItem.WorldPositionY);
            }

            // right patch
            if (IsPatchPositionFree(rightX, farmPatchItem.WorldPositionY))
            {
                CreateConstructionPatchAt(rightX, farmPatchItem.WorldPositionY);
            }

            // up patch
            if (IsPatchPositionFree(farmPatchItem.WorldPositionX, upY))
            {
                CreateConstructionPatchAt(farmPatchItem.WorldPositionX, upY);
            }

            // down patch
            if (IsPatchPositionFree(farmPatchItem.WorldPositionX, downY))
            {
                CreateConstructionPatchAt(farmPatchItem.WorldPositionX, downY);
            }
        }

        Debug.Log("edit mode started!");
    }

    public bool IsPatchPositionFree(int x, int y)
    {
        if (world.Where(item => item.WorldPositionX == x && item.WorldPositionY == y).FirstOrDefault() != null)
        {
            return false;
        }

        if (currentConstructionPatches.Where(item => item.WorldPositionX == x && item.WorldPositionY == y).FirstOrDefault() != null)
        {
            return false;
        }

        return true;
    }



    public void DisableEditMode()
    {
        // remove all construction patches

        var constructionPatchList = GameObject.FindGameObjectsWithTag("CONSTRUCTION_PATCH");

        foreach(GameObject c in constructionPatchList)
        {
            Destroy(c);
        }

        currentConstructionPatches.Clear();
        currentConstructionPatches = new List<ConstructionPatch>();

        Debug.Log("edit mode finished!");
    }

}
