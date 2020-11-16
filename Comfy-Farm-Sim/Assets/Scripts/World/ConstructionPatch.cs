using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionPatch : MonoBehaviour
{
    private GameObject worldRef = null;
    public int WorldPositionX = 0;
    public int WorldPositionY = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(int x, int y, GameObject worldParent)
    {
        WorldPositionX = x;
        WorldPositionY = y;

        worldRef = worldParent;
        this.transform.parent = worldRef.transform;
    }

    #region InteractionMethods
    public void MouseEnter()
    {
        this.gameObject.GetComponent<Renderer>().material = worldRef.GetComponent<World>().prefabList.constructionPatchSelected;
    }

    public void MouseLeave()
    {
        this.gameObject.GetComponent<Renderer>().material = worldRef.GetComponent<World>().prefabList.constructionPatchNormal;
    }
    #endregion
}
