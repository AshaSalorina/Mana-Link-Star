using Asha.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asha.Data
{
    public class TestFuwenInfo_1: BaseFuwenInfo
    {
        public int BaseDmg = 1;
        public bool dmgAllEnemy = true;
        public TestFuwenInfo_1()
        {
            Mana = 100;
            词缀 = new string[0];
            名称 = "测试用名称";
            描述 = "测试用符文";
        }

        public override void 主星()
        {
            BaseDmg = 4;
            dmgAllEnemy = false;
        }

        public override void 辅星()
        {
            BaseDmg = 1;
            dmgAllEnemy = true;
        }

        public override void 星天冲日()
        {
            if (dmgAllEnemy)
            {
                foreach (var enemy in MainBattleBhv.NowBattle.Enemys)
                {
                    enemy.SubHp(BaseDmg);
                }
            }
            else
            {
                MainBattleBhv.NowBattle.Enemys[0].SubHp(BaseDmg);
            }


            MessagesManager.GetMessageManager().SendMessage("全体伤害", 1);
        }
    }
    public class TestFuwen : BaseFuwen
    {
        private void Start()
        {
            Info = new TestFuwenInfo_1();
        }


        private void OnTriggerEnter(Collider other)
        {
            Info.星天冲日();
        }

    }

}

