using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBlock : MonoBehaviour{

    public GameObject confettiFX;
    public GameObject enemyPrefab;
    public GameObject goodItemPrefab;
    public GameObject negativeItemPrefab;

    void Start(){
        
    }

    void Update(){
        if(LevelEditor.isOnEditorMode)
            return;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Vector3 position = new Vector3(transform.position.x, transform.position.y + 0.4f, 0);
        int randomItem = Random.Range(0, 3);

        if(randomItem == 0){
            GameObject confettiLifetime = Instantiate(confettiFX, position, transform.rotation);
            Destroy(confettiLifetime, 3.5f);
            Instantiate(goodItemPrefab, position, transform.rotation);
            Instantiate(goodItemPrefab, position, transform.rotation);
            Instantiate(goodItemPrefab, position, transform.rotation);
        }else if(randomItem == 1){
            Instantiate(negativeItemPrefab, position, transform.rotation);
        }else{
            Instantiate(enemyPrefab, position, transform.rotation);
        }

        Destroy(gameObject);

    }

}
