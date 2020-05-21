using Asha.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asha.Data;

namespace Asha.Managers
{
    /**
     * 理论模型：
     *  所有的消息分为两类：
     *      世界发生了什么变化（MessagesManager）
     *      ”我“发生了什么变化（ashagameobject.sendmessage）
     */

    // 消息监听器
    public delegate void MessageListener(params object[] 参数表);
    // 消息销毁器
    public delegate void MessageCancler();

    /// <summary>
    /// 全局消息传递器
    /// </summary>
    public class MessagesManager: MonoBehaviour
    {
        protected static MessagesManager _inst;
        static MessagesManager()
        {
            if (_inst == null)
            {
                var go = new GameObject("MessagesManager");
                go.transform.SetParent(MOM.GetMOM().gameObject.transform);
                //DontDestroyOnLoad(go);
                _inst = go.AddComponent<MessagesManager>();
            }
        }

        /// <summary>
        /// 获取全局消息机
        /// </summary>
        /// <returns></returns>
        public static BaseAshaGameObject GetMessageManager()
        {
            return _inst.messagesManager;
        }

        protected BaseAshaGameObject messagesManager = new BaseAshaGameObject();
    }

    /// <summary>
    /// 游戏数据内目标的消息接口
    /// </summary>
    public interface IMessagesIO
    {
        void SendMessage(string 消息类型, params object[] args);

        MessageCancler ConnectMessage(string 消息类型, MessageListener listener);

        void DisconnectMessage(string 消息类型, MessageListener listener);
    }
}