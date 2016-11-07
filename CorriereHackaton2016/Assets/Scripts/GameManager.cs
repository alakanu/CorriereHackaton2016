using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public delegate void OnDifficultyRise();
    public static event OnDifficultyRise DifficultyRiseEvent;
    
}
