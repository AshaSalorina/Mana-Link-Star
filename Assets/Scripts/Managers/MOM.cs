using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asha.Managers
{
    /// <summary>
    /// managers管理器
    /// </summary>
    public class MOM : MonoBehaviour
    {
        protected static MOM _inst;
        static MOM()
        {
            if (_inst == null)
            {
                var go = new GameObject("MOM");
                DontDestroyOnLoad(go);
                _inst = go.AddComponent<MOM>();
            }
        }

        /// <summary>
        /// 获取MOM
        /// </summary>
        /// <returns></returns>
        public static MOM GetMOM()
        {
            return _inst;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

