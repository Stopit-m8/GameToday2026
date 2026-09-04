using UnityEngine;

[CreateAssetMenu(fileName = "NewMold", menuName = "Create New Mold")]
public class MoldSO : ScriptableObject
{
    public Sprite sprite;
    public Sprite cuttedSprite;
    public Sprite crackedSprite;
    public enum MoldType
    {
        star,
        diamond,
        crown,
        MC
    }
    public MoldType moldType;
}
