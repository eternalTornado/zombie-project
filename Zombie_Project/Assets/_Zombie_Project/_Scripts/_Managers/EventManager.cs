using System;
using UnityEngine;

public class EventManager
{
    //Game State Events
    public static Action GameStarted;
    public static Action GameEnded;

    //Player Movement Events
    public static Action<Vector2> LatestMovementInput;
    public static Action<Vector2> LatestMousePosition;

    //Player and Enemy Status Events
    public static Action EnemySpawned;
    public static Action EnemyKilled;
    public static Action<int> AddScoreToPlayer;
    public static Action<int> PlayerReceivedDamage;
    public static Action PlayerKilled;

    //Weapon related events
    public static Action PistolWeaponSelected;
    public static Action RifleWeaponSelected;
    public static Action WeaponFireStarted;
    public static Action WeaponFireStopped;

    //Audio related Events
    public static Action<AudioClip> PlaySFX;
    public static Action<AudioClip> PlayBGMusic;
}
