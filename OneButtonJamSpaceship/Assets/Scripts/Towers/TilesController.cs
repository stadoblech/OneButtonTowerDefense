using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TilesController : MonoBehaviour {

    public Color32 activeTileColor;
    public GameObject towerObject;

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

        defaultColor = tiles[0].GetComponent<SpriteRenderer>().color;
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
        tiles[activeTileIndex].GetComponent<SpriteRenderer>().color = activeTileColor;
        tiles[previousIndex].GetComponent<SpriteRenderer>().color = defaultColor;
    }

    void checkForTileAction()
    {
        if (InputController.keyCodeStatus == InputController.KeycodeStatus.Hold)
        {
            GameObject activeTower = tiles[activeTileIndex];
            TowerActivator towerActivation = activeTower.GetComponent<TowerActivator>();
            if (!towerActivation.towerActivated)
            {
                Instantiate(towerObject, activeTower.transform.position, Quaternion.identity, activeTower.transform);
                towerActivation.towerActivated = true;
            }
            InputController.resetKeycodeStatus();
            return;
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
