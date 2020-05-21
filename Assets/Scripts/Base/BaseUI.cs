using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asha.UI
{
    public class BaseUI
    {
        public string ClassName
        {
            get
            {
                return GetType().Name;
            }
        }

        /// <summary>
        /// UI的游戏对象
        /// </summary>
        public GameObject GameObject
        {
            get;
            set;
        }

        /// <summary>
        /// UI的资源位置
        /// </summary>
        public virtual string Resource
        {
            get
            {
                return "Prefabs/Main/WarehouseUI";
            }
        }

        public virtual void Init()
        {
        }

        public virtual void OnDestory()
        {
        }
    }
}