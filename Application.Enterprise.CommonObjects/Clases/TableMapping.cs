using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    public class TableMapping
    {
        public TableMapping()
        {
            Fields = new List<FieldMapping>();
        }

        public TableMapping(String tableName, String className)
        {
            this.tableName = tableName;
            this.className = className;
            Fields = new List<FieldMapping>();

        }

        private String tableName;

        public String TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        private String className;

        public String ClassName
        {
            get { return className; }
            set { className = value; }
        }

        public List<FieldMapping> Fields;
    }
}