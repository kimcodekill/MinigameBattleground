using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    [SerializeField] private Mesh titleMesh;
    [SerializeField, Multiline] private string description;
    
    public abstract void AddScore(int score);
    public Mesh TitleMesh => titleMesh;
    public string Description => description;
}
