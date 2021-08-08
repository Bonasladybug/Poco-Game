using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "NPC/Partner")]

public class NPC : ScriptableObject
{
    new public string name = "New Partner";
    public Sprite icon = null;    
    public int mood;    
}
