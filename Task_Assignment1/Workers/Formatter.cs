using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_Assignment1.Models;

namespace Task_Assignment1.Workers
{
    public class Formatter
    {
        private bool flag = false;
        private List<JsonDataObject> Format(List<JsonDataObject> obj, JsonDataObject obj2)
        {
            flag = false;
            for (int i = 0; i < obj.Count(); i++)
            {
                if (obj[i].children.Any() && obj[i].id != obj2.parent_id)
                {
                    if (obj[i].id != obj[i].parent_id)
                    {
                        Format(obj[i].children, obj2);
                    }
                }
                else if (obj[i].id == obj2.parent_id)
                {
                    if (!obj[i].children.Contains(obj2))
                    {
                        obj[i].children.Add(obj2);
                        flag = true;
                        break;
                    }
                }
            }
            return obj;
        }

        public List<JsonDataObject> JsonFormatter(string nonFormattedJson)
        {
            List<JsonDataObject> jsonDataObject = new List<JsonDataObject>();

            var obj = JsonConvert.DeserializeObject<object>(nonFormattedJson);

            JArray jArray = new JArray(obj);

            JToken jToken = jArray[0];

            var childrenData = jToken.Children().ToList();


            for (int i = 0; i < childrenData.Count; i++)
            {
                var data = childrenData[i].ToList();
                string jsonData = data.Last().ToString();
                jsonDataObject.AddRange(JsonConvert.DeserializeObject<List<JsonDataObject>>(jsonData));
            }

            List<JsonDataObject> result = new List<JsonDataObject>();
            for (int i = 0; i < jsonDataObject.Count; i++)
            {
                int j = i + 1;
                while (j != jsonDataObject.Count)
                {
                    jsonDataObject = Format(jsonDataObject, jsonDataObject[j]);
                    if (flag != true)
                    {
                        j++;
                    }
                    else
                    {
                        jsonDataObject.Remove(jsonDataObject[j]);
                    }
                }
            }
            return jsonDataObject;
        }
    }
}