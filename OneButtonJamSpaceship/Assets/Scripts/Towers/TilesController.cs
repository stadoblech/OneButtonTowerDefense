using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TilesController : MonoBehaviour {

    public Color32 activeTileColor;
    public GameObject towerObject;
    public float costForBuildingTower;

    List<GameObject> tiles;

    int activeTileIndex;

    Color32 defaultColor;

	void Start () {
        activeTileIndex = 0;

        tiles = new List<GameObject>();

        foreach(Transform t in transform)
        {
            tiles.Add(t.gameObject);
        }

        defaultColor = tiles[0].GetComponent<TextMesh>().color;

        for(int i = 0;i<tiles.Count;i++)
        {
            tiles[i].GetComponent<TextMesh>().text = (i + 1).ToString();
        }
    }
	
	void Update () {
        renderActiveTile();
        checkForTileAction();
	}

    void renderActiveTile()
    {
        int previousIndex = activeTileIndex - 1;
        if(previousIndex < 0)
        {
            previousIndex = tiles.Count-1;
        }
        tiles[activeTileIndex].GetComponent<TextMesh>().color = activeTileColor;
        tiles[previousIndex].GetComponent<TextMesh>().color = defaultColor;
    }

    void checkForTileAction()
    {
        if (InputController.keyCodeStatus == InputController.KeycodeStatus.Hold)
        {
            GameObject activeTower = tiles[activeTileIndex];
            TowerActivator towerActivation = activeTower.GetComponent<TowerActivator>();
            if (!towerActivation.towerActivated)
            {
                Vector3 shiftedPosition = new Vector3(activeTower.transform.position.x-0.01f,activeTower.transform.position.y-0.05f);
                Instantiate(towerObject, shiftedPosition, Quaternion.identity, activeTower.transform);
                towerActivation.towerActivated = true;
            }
            InputController.resetKeycodeStatus();
        }
        if (InputController.keyCodeStatus == InputController.KeycodeStatus.Pressed)
        {
            activeTileIndex++;
            if(activeTileIndex > tiles.Count-1)
            {
                activeTileIndex = 0;
            }
            InputController.resetKeycodeStatus();
        }
    }


}
