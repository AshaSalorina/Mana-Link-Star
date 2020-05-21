using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asha.Data
{
    /// <summary>
    /// 主战斗逻辑
    /// </summary>
    public class MainBattleBhv
    {
        private static MainBattleBhv _inst;
        static MainBattleBhv GetBattleBhv()
        {
            if(_inst != null)
            {
                _inst = new MainBattleBhv();
            }
            return _inst;
        }

        public MainBattleBhv()
        {
            Init();
        }

        /// <summary>
        /// 结算数据
        /// </summary>
        public class EndBattleInfo
        {

        }
        /// <summary>
        /// 管存战斗数据
        /// </summary>
        public class Battle
        {
            public List<BaseCharacter> Enemys = new List<BaseCharacter>();
        }

        private static Battle nowBattle;

        public static Battle NowBattle { get => nowBattle; }

        /// <summary>
        /// 初始化战斗
        /// </summary>
        /// <returns></returns>
        public Battle Init()
        {
            nowBattle = new Battle();
            return NowBattle;
        }
    }

}


