using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//This script is attached to the tile editor object
public class LevelEditor : MonoBehaviour{
    
    public TileManager[] tiles;
    public GameObject[] buttonsToHide;
    public SpriteRenderer preview;
    public static bool isOnEditorMode;
    int id;
    
    void Start(){
        isOnEditorMode = true;

        int i = 0;
        foreach(Transform child in this.transform){
            if(child.GetComponent<Button>()){
                int u = i;
                child.GetComponent<Button>().onClick.AddListener(()=>{
                    id = u;
                    preview.sprite = tiles[u].sprite;
                });
                i++;
            }
        }
    }

    void Update(){
        if(UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            return;
        if(!isOnEditorMode)
            return;

        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        pos.x = Mathf.RoundToInt(pos.x);
        pos.y = Mathf.RoundToInt(pos.y);

        preview.transform.position = pos;

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            var check = Physics2D.CircleCast(pos, 0.2f, Vector2.zero);
            if(check.collider == null)
                Instantiate(tiles[id].gameObject, pos, Quaternion.identity);
        }

        if(Input.GetKeyDown(KeyCode.Delete)){
            var check = Physics2D.CircleCast(pos, 0.5f, Vector2.zero);
            if(check.collider != null)
                Destroy(check.collider.gameObject);
        }
    }

    public void ToggleEditorMode(){
        isOnEditorMode = !isOnEditorMode;
        preview.enabled = isOnEditorMode;

        for(int i = 0; i < buttonsToHide.Length; i++)
            buttonsToHide[i].SetActive(isOnEditorMode);
    }
}
