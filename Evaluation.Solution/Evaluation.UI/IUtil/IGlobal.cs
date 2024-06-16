namespace Evaluation.UI.IUtil
{
    public interface IGlobal
    {
        List<string> DecodeParameters(string ticket, int numberOfParameters);
        string EncodeParameters(string parameter);
        public List<IDictionary<string, string>> GetDictoinaryListFromDynamicList(List<dynamic> result);
        List<List<IDictionary<string, string>>> ConvertDictionaryListOfListDynamicListOfList(List<dynamic> result);
    }
}
