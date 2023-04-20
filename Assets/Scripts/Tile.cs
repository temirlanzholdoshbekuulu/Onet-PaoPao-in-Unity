using UnityEngine;

public class Tile : MonoBehaviour
{
    public int x;
    public int y;
    public Tile[,] grid;
    public bool isEmpty = false;
    public bool isChecked;
    [SerializeField] Sprite emptyTile;
    
    private void Start() 
    {
        name = this.gameObject.name;
    }
    public void MakeEmpty()
    {
        isEmpty = true;
        this.GetComponent<SpriteRenderer>().material.color = new Color(0, 0, 0, -0.3f);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
