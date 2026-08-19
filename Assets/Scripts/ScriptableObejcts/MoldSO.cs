using UnityEngine;

[CreateAssetMenu(fileName = "NewMold", menuName = "Create New Mold")]
public class MoldSO : ScriptableObject
{
    public Sprite sprite;
    public enum MoldType
    {
        star,
        diamond,
        crown
    }
    public MoldType moldType;
}
