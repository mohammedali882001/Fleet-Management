using System.Collections.Generic;

namespace AnasProject.DTOS
{
    public class GVARDTO
    {
        public Dictionary<string, Dictionary<string, string>> DicOfDic { get; set; }

        public GVARDTO()
        {
            DicOfDic = new Dictionary<string, Dictionary<string, string>>();
        }
    }
}
