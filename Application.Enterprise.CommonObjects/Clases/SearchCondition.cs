using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{

    
    public class SearchCondition
    {
        public SearchCondition()
        {
        }
        
        public string GetFilterQuery()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" AND {0}  {1} {2}", Field, FilterOperator, FieldValue);            
            return sb.ToString();
        }

        public SearchCondition(string filterOperator, string field, string fieldValueTxt, string conditionOperatorTxt, string fieldTxt)
        {
            this.filterOperator = filterOperator;
            this.field = field;
            this.fieldValueTxt = fieldValueTxt;
            this._conditionOperatorTxt = conditionOperatorTxt;
            this._fieldTxt = fieldTxt;
        }
        public SearchCondition(string filterOperator, string field, string fieldValueTxt, string conditionOperatorTxt, string fieldTxt, string fieldValue)
        {
            this.filterOperator = filterOperator;
            this._conditionOperatorTxt = conditionOperatorTxt;
            this.field = field;
            this._fieldTxt = fieldTxt;
            this.fieldValue = fieldValue;
            this.fieldValueTxt = fieldValueTxt;
        }

        public SearchCondition(string query)
        {
            string[] prov;

            //todo logica

            prov = query.Split(' ');

            this.filterOperator = prov[0];
            this.field = prov[1];
            this.fieldValue = prov[2];
            this._conditionOperatorTxt = prov[3];
            this._fieldTxt = prov[4];
        }

        public static List<SearchCondition> CreateSearchConditions(string query)
        {
            string[] prov;

            List<SearchCondition> list = new List<SearchCondition>();

            prov = query.Split('A');
            //todo logica

            foreach (string item in prov)
            {
                SearchCondition item2 = new SearchCondition(item.Trim());
                list.Add(item2);
            }
            return list;
        }

        public static string GetFilterQueryList(List<SearchCondition> lstItem)
        {
            string filter = "1 = 1";

            foreach (SearchCondition item in lstItem)
            {
                if (item != null)
                {
                    filter = filter + item.GetFilterQuery();
                }
            }
            return filter;
        }

        public static List<SearchCondition> AddConditions(List<SearchCondition> list1, List<SearchCondition> list2)
        {
            List<SearchCondition> res = new List<SearchCondition>(); 

            foreach (SearchCondition item in list1)
            {
                res.Add(item);
            }

            foreach (SearchCondition item in list2)
            {
                res.Add(item);
            }

            return res;
        }

        private string _conditionOperatorTxt;

        public string ConditionOperatorTxt
        {
            get { return _conditionOperatorTxt; }
            set { _conditionOperatorTxt = value; }
        }

        private string _fieldTxt;

        public string FieldTxt
        {
            get { return _fieldTxt; }
            set { _fieldTxt = value; }
        }

        private string filterOperator;
        public string FilterOperator
        {
            get { return filterOperator; }
            set { filterOperator = value; }
        }

        private string field;
        public string Field
        {
            get { return field; }
            set { field = value; }
        }

        private string fieldValue;
        public string FieldValue
        {
            get
            {
                if (FilterOperator == "LIKE")
                {
                    return "'%" + fieldValue.Replace("'", "") + "%'";
                }
                else if (fieldValue.StartsWith("("))
                {
                    return "'" + fieldValue + "'";
                }
                else
                {
                    return fieldValue;
                }
            }
        }

        private string fieldValueTxt;
        public string FieldValueTxt
        {
            get { return fieldValueTxt; }
            set { fieldValueTxt = value; }
        }
    }
}
