using Asha.Managers;
using Asha.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScene : MonoBehaviour
{
    public Button 进入战斗;
    public Button 仓库;
    public Button 退出;
    void Start()
    {
        进入战斗.onClick.AddListener(() =>
        {
            // todo:选择难度界面
            //UIManager.GetUIManager().CreateUI
        });

        仓库.onClick.AddListener(() => 
        {
            UIManager.GetUIManager().CreateUI<WarehouseUI_Info>();
        });

        退出.onClick.AddListener(() =>
        {
            // todo:save
            SceneManager.LoadScene("StartScene");
        });

    }
}
