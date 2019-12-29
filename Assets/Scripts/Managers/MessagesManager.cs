using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asha.Managers
{
    /**
     * 理论模型：
     *  所有的消息分为两类：
     *      世界发生了什么变化（MessagesManager）
     *      ”我“发生了什么变化（gameobject.sendmessage）
     */

    public delegate void 监听器(object[] 参数表 = null);

    /// <summary>
    /// 消息类型列表
    /// </summary>
    public enum MessageType
    {

    }


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
                DontDestroyOnLoad(go);
                _inst = go.AddComponent<MessagesManager>();
            }
        }

        /// <summary>
        /// 获取MOM
        /// </summary>
        /// <returns></returns>
        public static MessagesManager GetMOM()
        {
            return _inst;
        }

        private  Dictionary<MessageType, List<监听器>> messages;

        /// <summary>
        /// 监听列表
        /// </summary>
        public  Dictionary<MessageType, List<监听器>> Messages => messages;

        /// <summary>
        /// 设置监听方法
        /// </summary>
        /// <param name="消息类型"></param>
        /// <param name="listener"></param>
        public  void ConnectMessage(MessageType 消息类型, 监听器 listener)
        {
            if (messages.ContainsKey(消息类型))
            {
                messages[消息类型].Add(listener);
            }
            else
            {
                var 监听器组 = new List<监听器>
                {
                    listener
                };
                messages.Add(消息类型, 监听器组);
            }
        }

        /// <summary>
        /// 断开监听方法
        /// </summary>
        /// <param name="消息类型"></param>
        /// <param name="listener"></param>
        public  void DisconnectMessage(MessageType 消息类型, 监听器 listener)
        {
            if (messages.ContainsKey(消息类型))
            {
                messages[消息类型].Remove(listener);
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="消息类型"></param>
        /// <param name="参数表"></param>
        public  void SendMessage(MessageType 消息类型, object[] 参数表 = null)
        {
            Debug.Log($"事件{消息类型}被触发");
            //依次执行所有监听该消息的方法
            if (messages.ContainsKey(消息类型))
            {
                foreach (var func in messages[消息类型])
                {
                    func(参数表);
                }
            }
        }
    }
}