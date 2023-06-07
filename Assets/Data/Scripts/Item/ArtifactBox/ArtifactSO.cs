using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Artifact", menuName = "SO/Artifact")]
public class ArtifactSO : ScriptableObject
{
    public Sprite sprite;
    public List<ArtifactAttribute> listProperties;
    public String detail;
}

[Serializable]
public struct ArtifactAttribute
{
    public TypeSkill typeSkill;
    public TypeAttribute typeAttribute;
    public float value;
}
public enum TypeSkill
{
    Fireball,
    FireZone,
    ElectricOrb,
    Satellite,
    WaterSpark,
    Thunderstorm,
    Spitrit,
}
public enum TypeAttribute
{
    damage,
    countdown,
    size,
    duration,
    bulletNumber,
    rangeExplosion,
    speed,
}