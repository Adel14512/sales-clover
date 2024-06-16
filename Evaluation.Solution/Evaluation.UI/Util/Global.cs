using Evaluation.UI.IUtil;
using System.Collections.Generic;
using System.Text.Json;

namespace Evaluation.UI.Util
{
    public class Global :IGlobal
    {
        public  string EncodeParameters(string parameter)
        {
            byte[] encoded = System.Text.Encoding.UTF8.GetBytes(parameter);
            return Convert.ToBase64String(encoded);
        }
        public  List<string> DecodeParameters(string ticket, int numberOfParameters)
        {
            List<string> parameters = new List<string>();
            byte[] encoded = Convert.FromBase64String(ticket);
            string decrypted = System.Text.Encoding.UTF8.GetString(encoded);
            string firstParam = string.Empty;
            string secondParam = string.Empty;
            string thirdParam = string.Empty;
            string fourthParam = string.Empty;
            string fifthParam = string.Empty;
            string sixthParam = string.Empty;
            string seventhParam = string.Empty;
            string eighthParam = string.Empty;
            string ninethParam = string.Empty;
            string tenthParam = string.Empty;
            string eleventhParam = string.Empty;

            switch (numberOfParameters)
            {
                case 1:
                    parameters.Add(decrypted.Split('=').GetValue(1).ToString());
                    break;

                case 2:
                    firstParam = decrypted.Split('&').GetValue(0).ToString();
                    secondParam = decrypted.Split('&').GetValue(1).ToString();

                    parameters.Add(firstParam.Split('=').GetValue(1).ToString());
                    parameters.Add(secondParam.Split('=').GetValue(1).ToString());
                    break;

                case 3:
                    firstParam = decrypted.Split('&').GetValue(0).ToString();
                    secondParam = decrypted.Split('&').GetValue(1).ToString();
                    thirdParam = decrypted.Split('&').GetValue(2).ToString();

                    parameters.Add(firstParam.Split('=').GetValue(1).ToString());
                    parameters.Add(secondParam.Split('=').GetValue(1).ToString());
                    parameters.Add(thirdParam.Split('=').GetValue(1).ToString());
                    break;
                case 4:
                    firstParam = decrypted.Split('&').GetValue(0).ToString();
                    secondParam = decrypted.Split('&').GetValue(1).ToString();
                    thirdParam = decrypted.Split('&').GetValue(2).ToString();
                    fourthParam = decrypted.Split('&').GetValue(3).ToString();

                    parameters.Add(firstParam.Split('=').GetValue(1).ToString());
                    parameters.Add(secondParam.Split('=').GetValue(1).ToString());
                    parameters.Add(thirdParam.Split('=').GetValue(1).ToString());
                    parameters.Add(fourthParam.Split('=').GetValue(1).ToString());
                    break;
                case 5:
                    firstParam = decrypted.Split('&').GetValue(0).ToString();
                    secondParam = decrypted.Split('&').GetValue(1).ToString();
                    thirdParam = decrypted.Split('&').GetValue(2).ToString();
                    fourthParam = decrypted.Split('&').GetValue(3).ToString();
                    fifthParam = decrypted.Split('&').GetValue(4).ToString();

                    parameters.Add(firstParam.Split('=').GetValue(1).ToString());
                    parameters.Add(secondParam.Split('=').GetValue(1).ToString());
                    parameters.Add(thirdParam.Split('=').GetValue(1).ToString());
                    parameters.Add(fourthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(fifthParam.Split('=').GetValue(1).ToString());
                    break;
                case 6:
                    firstParam = decrypted.Split('&').GetValue(0).ToString();
                    secondParam = decrypted.Split('&').GetValue(1).ToString();
                    thirdParam = decrypted.Split('&').GetValue(2).ToString();
                    fourthParam = decrypted.Split('&').GetValue(3).ToString();
                    fifthParam = decrypted.Split('&').GetValue(4).ToString();
                    sixthParam = decrypted.Split('&').GetValue(5).ToString();

                    parameters.Add(firstParam.Split('=').GetValue(1).ToString());
                    parameters.Add(secondParam.Split('=').GetValue(1).ToString());
                    parameters.Add(thirdParam.Split('=').GetValue(1).ToString());
                    parameters.Add(fourthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(fifthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(sixthParam.Split('=').GetValue(1).ToString());
                    break;
                case 7:
                    firstParam = decrypted.Split('&').GetValue(0).ToString();
                    secondParam = decrypted.Split('&').GetValue(1).ToString();
                    thirdParam = decrypted.Split('&').GetValue(2).ToString();
                    fourthParam = decrypted.Split('&').GetValue(3).ToString();
                    fifthParam = decrypted.Split('&').GetValue(4).ToString();
                    sixthParam = decrypted.Split('&').GetValue(5).ToString();
                    seventhParam = decrypted.Split('&').GetValue(6).ToString();

                    parameters.Add(firstParam.Split('=').GetValue(1).ToString());
                    parameters.Add(secondParam.Split('=').GetValue(1).ToString());
                    parameters.Add(thirdParam.Split('=').GetValue(1).ToString());
                    parameters.Add(fourthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(fifthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(sixthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(seventhParam.Split('=').GetValue(1).ToString());
                    break;
                case 8:
                    firstParam = decrypted.Split('&').GetValue(0).ToString();
                    secondParam = decrypted.Split('&').GetValue(1).ToString();
                    thirdParam = decrypted.Split('&').GetValue(2).ToString();
                    fourthParam = decrypted.Split('&').GetValue(3).ToString();
                    fifthParam = decrypted.Split('&').GetValue(4).ToString();
                    sixthParam = decrypted.Split('&').GetValue(5).ToString();
                    seventhParam = decrypted.Split('&').GetValue(6).ToString();
                    eighthParam = decrypted.Split('&').GetValue(7).ToString();

                    parameters.Add(firstParam.Split('=').GetValue(1).ToString());
                    parameters.Add(secondParam.Split('=').GetValue(1).ToString());
                    parameters.Add(thirdParam.Split('=').GetValue(1).ToString());
                    parameters.Add(fourthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(fifthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(sixthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(seventhParam.Split('=').GetValue(1).ToString());
                    parameters.Add(eighthParam.Split('=').GetValue(1).ToString());
                    break;
                case 9:
                    firstParam = decrypted.Split('&').GetValue(0).ToString();
                    secondParam = decrypted.Split('&').GetValue(1).ToString();
                    thirdParam = decrypted.Split('&').GetValue(2).ToString();
                    fourthParam = decrypted.Split('&').GetValue(3).ToString();
                    fifthParam = decrypted.Split('&').GetValue(4).ToString();
                    sixthParam = decrypted.Split('&').GetValue(5).ToString();
                    seventhParam = decrypted.Split('&').GetValue(6).ToString();
                    eighthParam = decrypted.Split('&').GetValue(7).ToString();
                    ninethParam = decrypted.Split('&').GetValue(8).ToString();

                    parameters.Add(firstParam.Split('=').GetValue(1).ToString());
                    parameters.Add(secondParam.Split('=').GetValue(1).ToString());
                    parameters.Add(thirdParam.Split('=').GetValue(1).ToString());
                    parameters.Add(fourthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(fifthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(sixthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(seventhParam.Split('=').GetValue(1).ToString());
                    parameters.Add(eighthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(ninethParam.Split('=').GetValue(1).ToString());
                    break;
                case 10:
                    firstParam = decrypted.Split('&').GetValue(0).ToString();
                    secondParam = decrypted.Split('&').GetValue(1).ToString();
                    thirdParam = decrypted.Split('&').GetValue(2).ToString();
                    fourthParam = decrypted.Split('&').GetValue(3).ToString();
                    fifthParam = decrypted.Split('&').GetValue(4).ToString();
                    sixthParam = decrypted.Split('&').GetValue(5).ToString();
                    seventhParam = decrypted.Split('&').GetValue(6).ToString();
                    eighthParam = decrypted.Split('&').GetValue(7).ToString();
                    ninethParam = decrypted.Split('&').GetValue(8).ToString();
                    tenthParam = decrypted.Split('&').GetValue(9).ToString();

                    parameters.Add(firstParam.Split('=').GetValue(1).ToString());
                    parameters.Add(secondParam.Split('=').GetValue(1).ToString());
                    parameters.Add(thirdParam.Split('=').GetValue(1).ToString());
                    parameters.Add(fourthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(fifthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(sixthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(seventhParam.Split('=').GetValue(1).ToString());
                    parameters.Add(eighthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(ninethParam.Split('=').GetValue(1).ToString());
                    parameters.Add(tenthParam.Split('=').GetValue(1).ToString());
                    break;
                case 11:
                    firstParam = decrypted.Split('&').GetValue(0).ToString();
                    secondParam = decrypted.Split('&').GetValue(1).ToString();
                    thirdParam = decrypted.Split('&').GetValue(2).ToString();
                    fourthParam = decrypted.Split('&').GetValue(3).ToString();
                    fifthParam = decrypted.Split('&').GetValue(4).ToString();
                    sixthParam = decrypted.Split('&').GetValue(5).ToString();
                    seventhParam = decrypted.Split('&').GetValue(6).ToString();
                    eighthParam = decrypted.Split('&').GetValue(7).ToString();
                    ninethParam = decrypted.Split('&').GetValue(8).ToString();
                    tenthParam = decrypted.Split('&').GetValue(9).ToString();
                    eleventhParam = decrypted.Split('&').GetValue(10).ToString();

                    parameters.Add(firstParam.Split('=').GetValue(1).ToString());
                    parameters.Add(secondParam.Split('=').GetValue(1).ToString());
                    parameters.Add(thirdParam.Split('=').GetValue(1).ToString());
                    parameters.Add(fourthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(fifthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(sixthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(seventhParam.Split('=').GetValue(1).ToString());
                    parameters.Add(eighthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(ninethParam.Split('=').GetValue(1).ToString());
                    parameters.Add(tenthParam.Split('=').GetValue(1).ToString());
                    parameters.Add(eleventhParam.Split('=').GetValue(1).ToString());
                    break;
                default:
                    break;
            }

            return parameters;
        }
        public List<List<IDictionary<string, string>>> ConvertDictionaryListOfListDynamicListOfList(List<dynamic> result)
        {
            var resultList = new List<List<IDictionary<string, string>>>();

            foreach (var innerList in result)
            {
                var innerDictionaryList = new List<IDictionary<string, string>>();

                foreach (var dynamicArray in innerList)
                {
                    var dictionary = new Dictionary<string, string>();

                    // Extract properties from each dynamic item in the array
                    foreach (var dynamicItem in dynamicArray)
                    {
                        //// Assuming dynamicItem is an object with properties
                        //foreach (var property in dynamicItem.GetType().GetProperties())
                        //{
                            var propertyName = dynamicItem.Name;
                            var propertyValue = dynamicItem.Value.ToString();

                            dictionary[propertyName] = propertyValue;
                        //}
                    }

                    innerDictionaryList.Add(dictionary);
                }

                resultList.Add(innerDictionaryList);
            }

            return resultList;
        }


        public List<IDictionary<string, string>> GetDictoinaryListFromDynamicList(List<dynamic> result)
        {
            List<IDictionary<string, string>> dynamicDictionary = new List<IDictionary<string, string>>();
            if (result != null)
            {

                foreach (var item in result)
                {
                    var dictionary = new Dictionary<string, string>();

                        foreach (var property in item)
                        {
                            dictionary.Add(((Newtonsoft.Json.Linq.JProperty)property).Name.ToString(), ((Newtonsoft.Json.Linq.JProperty)property).Value.ToString());
                        }
                        dynamicDictionary.Add(dictionary);
                    
                    
                }
            }
          

            return dynamicDictionary;
        }
    }

}
