using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Application.Enterprise.CommonObjects
{
    public class FieldMapping
    {
        public FieldMapping()
        {

        }

        public FieldMapping(String fieldName, DbType fieldType, String propertyName, String propertyType)
        {
            this.fieldName = fieldName;
            this.propertyName = propertyName;
            this.fieldType = fieldType;
            this.propertyType = propertyType;
        }

        private String fieldName;

        public String FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }

        private DbType fieldType;

        public DbType FieldType
        {
            get { return fieldType; }
            set { fieldType = value; }
        }

        private String propertyName;

        public String PropertyName
        {
            get { return propertyName; }
            set { propertyName = value; }
        }

        private String propertyType;

        public String PropertyType
        {
            get { return propertyType; }
            set { propertyType = value; }
        }

    }
}
