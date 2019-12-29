using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asha.Data;
using UnityEngine.UI;

namespace Asha.UI
{
    public class WarehouseUI : BaseUI
    {
        #region 仓库按钮组

        [Header("仓库按钮组")]
        public Button 查看符文;

        public Button 查看基盘;
        public Button 配置符文;
        public Button 退出;

        private ButtonSingle 仓库按钮组 = new ButtonSingle();

        #endregion 仓库按钮组

        #region 仓库页面组

        [Header("仓库页面组")]
        public GameObject 查看符文页面;

        public GameObject 查看基盘页面;
        public GameObject 配置符文页面;

        private GameObjectSingle 仓库页面组 = new GameObjectSingle();

        #endregion 仓库页面组

        public override string Resource => "Prefabs/Main/WarehouseUI";

        public override void Init()
        {
            try
            {
                仓库按钮组.Add(查看符文)
                   .Add(查看基盘)
                   .Add(配置符文)
                   .Add(退出);
                仓库按钮组.反转 = true;

                仓库页面组.Add(查看符文页面)
                    .Add(查看基盘页面)
                    .Add(配置符文页面);

                查看基盘.onClick.AddListener(() =>
                {
                    仓库页面组.Choise(查看基盘页面);
                });
                查看符文.onClick.AddListener(() =>
                {
                    仓库页面组.Choise(查看符文页面);
                });
                配置符文.onClick.AddListener(() =>
                {
                    仓库页面组.Choise(配置符文页面);
                });
                退出.onClick.AddListener(() =>
                {
                    //Managers.UIManager.
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}