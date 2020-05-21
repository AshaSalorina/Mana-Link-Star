using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asha.Managers;
public class TestIMIO : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TIMIO();
        gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(()=> {
            MessagesManager.GetMessageManager().SendMessage("TestMessage", "fuck akise");
        });
    }

    void TIMIO()
    {
        MessagesManager.GetMessageManager().ConnectMessage("TestMessage", (v) =>
        {
            if(v.Length == 1 && v[0].GetType() == typeof(string))
            {
                Debug.Log(v[0]);
            }
        });
    }
}
