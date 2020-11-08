using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Plants
{
    Tree
}

public class FarmPatchBehaviour : MonoBehaviour
{
    public Material farmPatchNormal;
    public Material farmPatchMouseOver;

    private PrefabCollection prefabList;

    public bool isEmpty = true;
    public bool isDoneGrowing = false;

    GameObject plantObject = null;

    // Start is called before the first frame update
    void Start()
    {
        isDoneGrowing = false;
        prefabList = GameObject.FindGameObjectWithTag("PREFAB_LIST").GetComponent<PrefabCollection>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MouseEnter()
    {
        this.gameObject.GetComponent<Renderer>().material = farmPatchMouseOver;
    }

    public void MouseLeave()
    {
        this.gameObject.GetComponent<Renderer>().material = farmPatchNormal;
    }

    public void Plant(Plants plantEnum)
    {
        switch (plantEnum)
        {
            case Plants.Tree:
                plantObject = Instantiate(prefabList.treePrefab, this.gameObject.transform.position, Quaternion.identity);
                break;
        }
        plantObject.transform.parent = this.gameObject.transform;
    }

    public void Harvest()
    {
        if(plantObject != null)
        {
            GameObject.Destroy(plantObject);
            plantObject = null;
            isEmpty = true;
            isDoneGrowing = false;
        }
    }
}
