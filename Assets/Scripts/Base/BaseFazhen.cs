using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asha.Data
{
    public class BaseFazhen : MonoBehaviour
    {
        /// <summary>
        /// prefab资源地址
        /// </summary>
        public readonly string Res;
        public string Name
        {
            get { return GetType().Name; }
        }

        public float Mana;

        public int 轨道数量;

        public float[] 转速;

    }
}

