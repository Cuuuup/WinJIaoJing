using System;
using System.Collections.Generic;

public class RandomController
{

    //待随机抽取数据集合

    public List<string> datas = new List<string>();


    //权值

    public List<ushort> weights = new List<ushort>();

    /// <summary>
    /// 随机抽取
    /// </summary>
    /// <param name="rand">随机数生成器</param>
    /// <returns></returns>
    public string[] ControllerRandomExtract(Random rand)
    {
        List<string> result = new List<string>();
        if (rand != null)
        {
            //临时变量

            Dictionary<string, int> dict = new Dictionary<string, int>(3);
            //为每个项算一个随机数并乘以相应的权值
            for (int i = datas.Count - 1; i >= 0; i--)
            {
                dict.Add(datas[i], rand.Next(100) * weights[i]);
            }
            //排序
            List<KeyValuePair<string, int>> listDict = SortByValue(dict);
            //拷贝抽取权值最大的前Count项
            foreach (KeyValuePair<string, int> kvp in listDict.GetRange(0, 1))
            {
                result.Add(kvp.Key);
            }
        }
        return result.ToArray();

    }

    #region Tools



    /// <summary>

    /// 排序集合

    /// </summary>

    /// <param name="dict"></param>

    /// <returns></returns>

    private List<KeyValuePair<string, int>> SortByValue(Dictionary<string, int> dict)

    {

        List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();



        if (dict != null)

        {

            list.AddRange(dict);



            list.Sort(

              delegate (KeyValuePair<string, int> kvp1, KeyValuePair<string, int> kvp2)

              {

                  return kvp2.Value - kvp1.Value;

              });

        }

        return list;

    }





    #endregion



}