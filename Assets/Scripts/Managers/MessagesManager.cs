using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asha.Data
{
    /**
     * 理论模型：
     *  所有的消息分为两类：
     *      世界发生了什么变化（MessagesManager）
     *      ”我“发生了什么变化（gameobject.sendmessage）
     */

    public delegate void 监听器(object[] 参数表 = null);

    /// <summary>
    /// 全局消息传递器
    /// </summary>
    public class MessagesManager
    {
        private static Dictionary<string, List<监听器>> messages;

        /// <summary>
        /// 监听列表
        /// </summary>
        public static Dictionary<string, List<监听器>> Messages => messages;

        /// <summary>
        /// 设置监听方法
        /// </summary>
        /// <param name="消息类型"></param>
        /// <param name="listener"></param>
        public static void ConnectMessage(string 消息类型, 监听器 listener)
        {
            if (Messages.ContainsKey(消息类型))
            {
                Messages[消息类型].Add(listener);
            }
            else
            {
                var 监听器组 = new List<监听器>
                {
                    listener
                };
                Messages.Add(消息类型, 监听器组);
            }
        }

        /// <summary>
        /// 断开监听方法
        /// </summary>
        /// <param name="消息类型"></param>
        /// <param name="listener"></param>
        public static void DisconnectMessage(string 消息类型, 监听器 listener)
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
        public static void SendMessage(string 消息类型, object[] 参数表 = null)
        {
            //依次执行所有监听该消息的方法
            if (Messages.ContainsKey(消息类型))
            {
                foreach (var func in Messages[消息类型])
                {
                    func(参数表);
                }
            }
        }
    }
}