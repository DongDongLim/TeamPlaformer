using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Data/SkillData")]//어떤이름인지 , 메뉴에서 어떻게 보일지
public class SkillData : Data
{
    [System.Serializable]
    public struct skillInfo
    {
        public int atk;//스킬의 공격력
        public float sec;//스킬의 지속시간 TODO: 몇초의 간격으로 공격처리 할지
        public float range;//스킬의 범위
        public bool isStun;//스턴유무
    }
    [SerializeField]
    public skillInfo m_skillInfo;//public으로 바꾸고   몬스터쪽에 지정해줌.

    [System.Serializable]
    public enum SkillType
    {
        NOMMAL,
        STUN,
        INSTANTKILL
    }
    [SerializeField]
    SkillType skillType;

    public SkillType Use()
    {
        return skillType;
    }
}
