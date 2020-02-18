using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enterprise.CommonObjects
{
    public class ConfigurationInstrumentsView : INotifyPropertyChanged, IDataErrorInfo
    {
        public virtual int IdConfiguration { get; set; }
        public virtual string NameUser { get; set; }
        public virtual bool Isdefault { get; set; }
        public virtual string NameConfiguration { get; set; }
        public virtual string XmlConfiguration { get; set; }
        //public virtual byte[] ImageConfiguration { get; set; }
        //public virtual Error Error { get; set; }
        //  public Image ImageImageconfiguration { get; set; }
        public virtual byte[] biteXmlConfiguration { get; set; }

        public virtual string NameNemotec { get; set; }

        public virtual List<string> NemotecnicsList { get; set; }

        string IDataErrorInfo.Error
        {
            get;
        }
        public Dictionary<string, string> Errors = new Dictionary<string, string>();
        public bool IsValidating = false;


        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                if (!IsValidating) return result;
                Errors.Remove(columnName);
                switch (columnName)
                {
                    case "NameConfiguration":
                        //if (string.IsNullOrEmpty(NameConfiguration)) result = TranslationManager.Instance.Translate("ConfiguracionRequerida").ToString(); 
                        break;
                }
                if (result != string.Empty) Errors.Add(columnName, result);
                return result;
            }
        }

        public bool IsValid()
        {
            IsValidating = true;
            try
            {
                OnPropertyChanged("NameConfiguration");
            }
            finally
            {
                IsValidating = false;
            }
            return (Errors.Count() == 0);
        }

        #region INotifyPropertyChanged Members
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
