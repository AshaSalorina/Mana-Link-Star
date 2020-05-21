using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asha.Managers;

namespace Asha.Data
{
    /// <summary>
    /// 基础内存数据域对象
    /// </summary>
    public class BaseAshaGameObject : IMessagesIO
    {
        private bool isDestroy = false;

        private readonly Dictionary<string, List<MessageListener>> messages = new Dictionary<string, List<MessageListener>>();

        private List<MessageCancler> canclers = new List<MessageCancler>();

        /// <summary>
        /// 监听列表
        /// </summary>
        protected Dictionary<string, List<MessageListener>> Messages => messages;

        public List<MessageCancler> Canclers { get => canclers; set => canclers = value; }

        /// <summary>
        /// 调用该方法使得事件监听可以在自身销毁时跟着断开连接
        /// </summary>
        /// <param name="listener"></param>
        public void AutoDisconnect(MessageCancler listener)
        {
            Canclers.Add(listener);
        }

        /// <summary>
        /// 设置监听方法
        /// </summary>
        /// <param name="消息类型"></param>
        /// <param name="listener"></param>
        public MessageCancler ConnectMessage(string 消息类型, MessageListener listener)
        {
            if (Messages.ContainsKey(消息类型))
            {
                Messages[消息类型].Add(listener);
            }
            else
            {
                var 监听器组 = new List<MessageListener>
                {
                    listener
                };
                Messages.Add(消息类型, 监听器组);
            }
            return () =>
            {
                DisconnectMessage(消息类型, listener);
            };
        }

        /// <summary>
        /// 断开监听方法
        /// </summary>
        /// <param name="消息类型"></param>
        /// <param name="listener"></param>
        public void DisconnectMessage(string 消息类型, MessageListener listener)
        {
            if (Messages.ContainsKey(消息类型))
            {
                Messages[消息类型].Remove(listener);
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="消息类型"></param>
        /// <param name="参数表"></param>
        public void SendMessage(string 消息类型, params object[] 参数表)
        {
            Debug.Log($"事件{消息类型}被触发");
            //依次执行所有监听该消息的方法
            if (Messages.ContainsKey(消息类型))
            {
                foreach (var func in Messages[消息类型])
                {
                    func(参数表);
                }
            }
        }

        protected virtual void OnDestroy()
        {
            if (isDestroy)
            {
                Debug.LogWarning("销毁函数被重复调用");
            }
            else
            {
                SendMessage("OnDestroy");
                isDestroy = true;
                foreach (var item in canclers)
                {
                    item();
                }
                Messages.Clear();
            }
            
        }

    }

}