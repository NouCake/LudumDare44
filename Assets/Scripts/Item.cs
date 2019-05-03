using UnityEngine;

[CreateAssetMenu(fileName = "newfile",  menuName ="Item/New Item")]
public class Item : ScriptableObject{

    public int id;
    public int price;
    new public string name = "Unnamed Item";
    public Sprite image = null;

}
