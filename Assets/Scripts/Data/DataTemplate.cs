using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "Game/ThingData")]
public class ThingData : ScriptableObject
{
    // public Thing ThingPrefab;

    [Header("Attributes")]
    [Space]
    public string Name;
    [Range(0,50)]
    public int Cost;
    [Range(0,5)]
    public int MaintenanceCost;
    [Range(0,100)]
    public int Health;
    [Range(1,10)]
    public int Range; // NOT IMPLEMENTED
    [Range(0.5f,4f)]
    public float ShootDelay;

    [Header("GUI Panel Attributes")]
    [Space]
    public string Shortcut;
    public Sprite Icon;

    [Header("Audio")]
    [Space]
    public AudioClipGroup BuildSound;

    [Header("Bullet")]
    [Space]
    [Range(1,5)]
    public int BulletDamage;
    [Range(1,20)]
    public float BulletSpeed;

}
