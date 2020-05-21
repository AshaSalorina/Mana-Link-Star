using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asha.Data
{
    public class BaseBuff
    {
        /// <summary>
        /// 持续时间
        /// </summary>
        public double Time { get; set; }

        public virtual void Init() { }

        public virtual void BeforeUpdate() { }

        public virtual void Update() { }

        public virtual void AfterUpdate() { }

        public virtual void Destroy() { }

    }
}

