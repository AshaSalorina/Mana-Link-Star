using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Asha.UI;

namespace Asha.Managers
{
    public class UIManager: MonoBehaviour
    {
        protected static UIManager _inst;
        static UIManager()
        {
            if(_inst == null)
            {
                var go = new GameObject("UIManager");
                go.transform.SetParent(MOM.GetMOM().gameObject.transform);
                DontDestroyOnLoad(go);
                _inst = go.AddComponent<UIManager>();
            }
        }
        public static UIManager GetUIManager()
        {
            return _inst;
        }

        ///// <summary>
        ///// UI根节点管理
        ///// </summary>
        //public Dictionary<string, Transform> UIRoot = new Dictionary<string, Transform>();

        /// <summary>
        /// UI堆管理
        /// </summary>
        private Dictionary<string, BaseUI> UIDictionary = new Dictionary<string, BaseUI>();

        /// <summary>
        /// UI调用栈
        /// 在一个无源头跳转之后UI的跳转历史应当被清空
        /// 栈中最多存放10个元素
        /// </summary>
        private List<BaseUI> UIHistory = new List<BaseUI>();

        /// <summary>
        /// 创建并显示UI
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T CreateUI<T>(bool callHistory = true) where T : BaseUI, new()
        {
            T ui = new T();
            if (!UIDictionary.ContainsKey(ui.ClassName))
            {
                // 创建对象
                ui.GameObject = GameObject.Instantiate(Resources.Load<GameObject>(ui.Resource));
                // 调用实例化方法
                ui.Init();
                UIDictionary.Add(ui.ClassName, ui);
            }
            else
            {
                ui = (T)UIDictionary[ui.ClassName];
            }
            // 调用显示
            EnableUI<T>();
            // 记录UI栈
            if (callHistory)
            {
                SetHistory(ui);
            }
            else
            {
                // 只要存在任意拒绝回溯的UI则清空所有历史记录
                UIHistory.Clear();
            }
            return ui;
        }

        /// <summary>
        /// 销毁指定UI对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void DestroyUI<T>(bool callHistory = true) where T : BaseUI, new()
        {
            // 先进行回调
            if (callHistory)
            {
                var history = CallHistory();
                if (history != null)
                {
                    history.GameObject.SetActive(true);
                    // 设置为最前
                    history.GameObject.transform.SetSiblingIndex(history.GameObject.transform.parent.childCount - 1);
                }
            }

            T ui = new T();
            if (UIDictionary.ContainsKey(ui.ClassName))
            {
                UIDictionary[ui.ClassName].OnDestory();
                GameObject.Destroy(UIDictionary[ui.ClassName].GameObject);
                UIDictionary.Remove(ui.ClassName);
            }
        }

        /// <summary>
        /// 隐藏UI
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CallHistory"></param>
        public void DisableUI<T>(bool callHistory = true) where T : BaseUI, new()
        {
            // 先进行回调
            if (callHistory)
            {
                var history = CallHistory();
                if (history != null)
                {
                    history.GameObject.SetActive(true);
                    // 设置为最前
                    history.GameObject.transform.SetSiblingIndex(history.GameObject.transform.parent.childCount - 1);
                }
            }

            T ui = new T();
            if (UIDictionary.ContainsKey(ui.ClassName))
            {
                UIDictionary[ui.ClassName].GameObject.SetActive(false);
            }
        }

        /// <summary>
        /// 启用UI
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CallHistory"></param>
        public void EnableUI<T>(bool callHistory = true) where T : BaseUI, new()
        {
            T ui = new T();
            if (UIDictionary.ContainsKey(ui.ClassName))
            {
                UIDictionary[ui.ClassName].GameObject.SetActive(true);
                // 设置为最前
                ui.GameObject.transform.SetSiblingIndex(ui.GameObject.transform.parent.childCount - 1);
            }
            if (callHistory)
            {
                SetHistory(ui);
            }
            else
            {
                UIHistory.Clear();
            }
        }

        /// <summary>
        /// 记录调用历史记录
        /// </summary>
        /// <param name="baseUI"></param>
        private void SetHistory(BaseUI baseUI)
        {
            UIHistory.Add(baseUI);
            while (UIHistory.Count > 10)
            {
                UIHistory.RemoveAt(0);
            }
        }

        /// <summary>
        /// 从末端调取UI历史记录
        /// </summary>
        private BaseUI CallHistory()
        {
            BaseUI history = null;
            if (UIHistory.Count > 0)
            {
                // 先移除当前栈顶对象
                UIHistory.RemoveAt(UIHistory.Count - 1);
                history = UIHistory[UIHistory.Count - 1];
            }
            return history;
        }
    }
}