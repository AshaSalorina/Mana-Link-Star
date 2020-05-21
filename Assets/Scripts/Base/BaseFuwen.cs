using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asha.Data
{
    public class BaseFuwenInfo
    {
        public string Name
        {
            get { return GetType().Name; }
        }

        public float Mana;

        public string[] 词缀;

        public virtual void 主星() { }
        public virtual void 辅星() { }
        public virtual void 星天冲日() { }

        public string 描述;
        public string 名称;
    }

    public class BaseFuwen : MonoBehaviour
    {
        public string Name
        {
            get { return GetType().Name; }
        }

        public BaseFuwenInfo Info;
    }
}

