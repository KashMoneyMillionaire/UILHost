using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace UILHost.Common
{
    public class TokenReplacer
    {
        readonly Regex _tokenPattern = new Regex(@"\$\{([a-zA-Z-_ ]*.[0-9a-zA-Z-_ ]*)\}");
        readonly TokenValuesCollection _tokenValuesCollection = null;

        public TokenReplacer() { }
		public TokenReplacer(string tokenValuesFilePath) 
        {
            this._tokenValuesCollection = new TokenValuesCollection(tokenValuesFilePath);
        }

        private string EvaluateToken(string token)
        {
            if (this._tokenValuesCollection == null)
                return null;
            return this._tokenValuesCollection[token];
        }

        public string ReplaceTokens(string template, object valueObject)
        {
            // evaluate type
            var valueObjectProperties = new PropertyInfo[] { };
            if(valueObject != null)
                valueObjectProperties = valueObject.GetType().GetProperties();

            var tokenValues = new Dictionary<string, string>();
            foreach (var prop in valueObjectProperties)
                tokenValues.Add(prop.Name, prop.GetValue(valueObject, new object[] { }).ToString());

            return this.ReplaceTokens(template, tokenValues);
        }

        public string ReplaceTokens(string template, Dictionary<string, string> tokenValues)
        {
            if (tokenValues == null)
                tokenValues = new Dictionary<string, string>();

            // match tokens and remove duplicates
            var tokenMatchCollection = _tokenPattern.Matches(template);

            var uniqueTokenList = new List<Match>();
            foreach (Match tokenMatch in tokenMatchCollection)
                if (!uniqueTokenList.Exists(m => m.Value.Equals(tokenMatch.Value)))
                    uniqueTokenList.Add(tokenMatch);

            foreach (var tokenMatch in uniqueTokenList)
            {
                var tokenContents = tokenMatch.Groups[1].Value;
                var token = tokenMatch.Value;

                var value = tokenValues.Where(v => v.Key.Equals(tokenContents, StringComparison.OrdinalIgnoreCase)).Select(v => v.Value).FirstOrDefault();

                if (value != null)
                    template = template.Replace(token, value);
                else if (this.EvaluateToken(tokenContents) != null)
                    template = template.Replace(token, this.EvaluateToken(tokenContents));
            }

            return template;
        }
    }
}
