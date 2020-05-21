using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asha.Managers
{
    public class GameManager : MonoBehaviour
    {
        protected static GameManager _inst;
        static GameManager()
        {
            if (_inst == null)
            {
                var go = new GameObject("GameManager");
                go.transform.SetParent(MOM.GetMOM().gameObject.transform);
                //DontDestroyOnLoad(go);
                _inst = go.AddComponent<GameManager>();
            }
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

