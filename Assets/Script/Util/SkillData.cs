using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Data/SkillData")]
public class SkillData : Data
{
    public int atk;
    [System.Serializable]
    public enum SkillType
    {
        NOMMAL,
        STUN,
        INSTANTKILL
    }
    [SerializeField]
    SkillType skillType;
}
