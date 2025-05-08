using UnityEngine;

[CreateAssetMenu(fileName = "MinigameData", menuName = "ScriptableObjects/MinigameData", order = 1)]
public class MinigameData : ScriptableObject
{
    public GameObject minigamePrefab;
    public float countdownTime;
    public string minigameName;
    public string minigamePrompt;
    public MinigameType minigameType;
    public Character character;
    public enum Character
    {
        Default,
        Mafia,
        Pirate_Queen,
        Raccoon
    }
    public enum MinigameType
    {
        Default,
        LoseByTimeout,
        WinByTimeout
    }
}
