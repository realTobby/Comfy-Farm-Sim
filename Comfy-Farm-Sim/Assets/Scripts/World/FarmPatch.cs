using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Plantables
{
    Tree,
    Bush,
    Plant
}

public class FarmPatch : MonoBehaviour
{
    private GameObject worldRef = null;

    public bool isEmpty = true;
    public bool isDoneGrowing = false;
    public GameObject plantObject = null;
    

    public int WorldPositionX = 0;
    public int WorldPositionY = 0;

    public void Initialize(int x, int y, GameObject worldParent)
    {
        WorldPositionX = x;
        WorldPositionY = y;

        isEmpty = true;
        isDoneGrowing = false;

        worldRef = worldParent;
        this.transform.parent = worldRef.transform;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region InteractionMethods
    public void MouseEnter()
    {
        this.gameObject.GetComponent<Renderer>().material = worldRef.GetComponent<World>().prefabList.farmPathSelected;
    }

    public void MouseLeave()
    {
        this.gameObject.GetComponent<Renderer>().material = worldRef.GetComponent<World>().prefabList.farmPatchNormal;
    }
    #endregion

    #region Farming Methods
    public void Plant(Plantables toPlant)
    {
        plantObject = null;
        switch (toPlant)
        {
            case Plantables.Tree:
                plantObject = Instantiate(worldRef.GetComponent<World>().prefabList.treePrefab, this.gameObject.transform.position, Quaternion.identity);
                break;
        }
        if(plantObject != null)
        {
            plantObject.transform.parent = this.gameObject.transform;
            isDoneGrowing = true;
            isEmpty = false;
        }
    }
    public void Harvest()
    {
        if (plantObject != null)
        {
            GameObject.Destroy(plantObject);
            plantObject = null;
            isEmpty = true;
            isDoneGrowing = false;
        }
    }
    #endregion



}
