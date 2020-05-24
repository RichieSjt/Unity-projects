using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private Color defaultColor = Color.gray;
    private bool isSelected = false;
    public bool isPattern = false;
    public bool isHiglighted = false;
    private bool playerLost = false;

    private void OnMouseDown()
    {   
        if(playerLost)
            return;
        if (!isSelected && !isHiglighted)
        {
            if (isPattern)
            {
                isSelected  = true;
                spriteRenderer.color = new Color((112f/255), (189f/255), (68f/255));
                BoardController.instance.counter++;
                if( BoardController.instance.counter == BoardController.instance.selectedTiles.Length){
                    ScoreController.instance.IncrementScore();
                    BoardController.instance.counter = 0;
                }

            }
            else
            {
                spriteRenderer.color = Color.red;
                playerLost = true;
                StartCoroutine(Reset(1f));
            }
        }

    }

    public void HiglightTile()
    {
        spriteRenderer.color = GenerateRandomColor();
        isHiglighted = true;
        StartCoroutine(UnhiglightTile(3f));
    }

    IEnumerator UnhiglightTile(float time)
    {
        yield return new WaitForSeconds(time);
        spriteRenderer.color = defaultColor;
        isHiglighted = false;
    }

     IEnumerator Reset(float time)
    {
        yield return new WaitForSeconds(time);
        ScoreController.instance.CompareScores();
        ScoreController.instance.DestroyPreviousBoard();
        ResetManager.playerLost = true;
    }

    public Color GenerateRandomColor()
    {
        Color NewColor;
        NewColor = new Color((Random.Range(70f,253f))/255, (Random.Range(137f,250f))/255,(Random.Range(81f,240f))/255);
        return NewColor;
    }
}
