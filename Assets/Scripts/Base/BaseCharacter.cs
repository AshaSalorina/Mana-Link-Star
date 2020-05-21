using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asha.Managers;

namespace Asha.Data
{

    public class CharacterProperties
    {
        #region 属性

        /// <summary>
        /// 资源路径
        /// </summary>
        public static string Path { get; }

        /// <summary>
        /// 角色名
        /// </summary>
        public static string CharacterName { get; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public string ID { get; set; }

        public string 法阵 { get; set; }

        /// <summary>
        /// 约定以|分割
        /// </summary>
        public string 符文 { get; set; }

        public double MaxMana { get; set; }

        /// <summary>
        /// 当前魔力值
        /// </summary>
        public double Mana { get; set; }

        private double usedMana;
        public double UsedMana
        {
            get
            {
                return usedMana;
            }
            set
            {
                //todo:设置mana越界反馈
                if (value > Mana)
                {
                    Debug.Log("Mana超界");
                }
                else
                {
                    usedMana = value;
                }
            }

        }

        #endregion
    }

    public class BaseCharacter : BaseAshaGameObject
    {
        public CharacterProperties characterProperties = new CharacterProperties();

        private int _Mana;

        public int Mana
        {
            get
            {
                return _Mana;
            }
            set
            {
                _Mana = value;
                if (_Mana < 0)
                {
                    Die();
                }
            }
        }

        public virtual void AddHp(int num)
        {
            Mana += num;
        }

        public virtual void SubHp(int num) 
        {
            Mana -= num;
        }

        public virtual void Die() { }

        public virtual void Init(){ }
        public virtual void BeforeUpdate() { }

        public virtual void Update() { }

        public virtual void AfterUpdate() { }

        public virtual void Destroy() { }
    }
}


