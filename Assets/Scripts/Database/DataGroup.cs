using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Asha.Data
{
    /// <summary>
    /// 所有的内存用数据存储位置
    /// </summary>
    public class DataGroup
    {
        private static TextDataStruct textData = new TextDataStruct();

        public static TextDataStruct TextData => textData;
        
        /// <summary>
        /// 存储玩家角色信息
        /// </summary>
        public static BaseCharacter Player;

        /// <summary>
        /// 存储战斗中的敌对单位信息
        /// </summary>
        public static BaseCharacter[] Enemys;


        /// <summary>
        /// 初始化默认描述文件
        /// </summary>
        public static void InitData()
        {
            var path = Application.streamingAssetsPath + $"/zh.csv";
            InitData(path);
        }

        /// <summary>
        /// 初始化各种描述数据
        /// </summary>
        /// <param name="datafile">文件路径</param>
        public static void InitData(string datafile)
        {
            try
            {
                StreamReader reader = new StreamReader(File.OpenRead(datafile));
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    // csv
                    // Menu key value....
                    var lineg = line.Split(',');
                    // 拼接
                    if (lineg.Length > 3)
                    {
                        for (int i = 3; i < lineg.Length; i++)
                        {
                            lineg[2] += lineg[i];
                        }
                    }

                    switch (lineg[0])
                    {
                        case "Menu":
                            textData.Menu.Add(lineg[1], lineg[2]);
                            break;

                        case "Skill":
                            textData.Skill.Add(lineg[1], lineg[2]);
                            break;

                        default:
                            Debug.Log($"在文件{datafile}中，存在不能识别的字典名{lineg[0]}");
                            break;
                    }
                }
                reader.Close();
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
                throw;
            }
            //TextData.Menu.Add()
        }

        public struct TextDataStruct
        {
            public Dictionary<string, string> Menu;

            public Dictionary<string, string> Skill;
        }
    }

}