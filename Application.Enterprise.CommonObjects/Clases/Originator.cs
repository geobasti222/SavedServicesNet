namespace Application.Enterprise.CommonObjects
{
    using System;
    using System.Collections.Generic;
    

    public class Originator 
	{
        /// <summary>
        /// Nombre Ordenante
        /// </summary>
        public virtual string NameOrd
        {
            get;
            set;
        }
      
        public virtual int NumPyP
        {
			get;
			set;
		}

	    public virtual string initialPswd
        {
	    	get;
			set;
		}

		public virtual int KeyExpiresDays 
        {
			get;
			set;
		}
		
		public virtual DateTime lastdateadmission
        {
            get;
            set;
        }

        public virtual string Profile
        {
            get;
            set;
        }

        
        public string IpAddress
        {
            get;
            set;
        }        

        public int City
        {
            get;
            set;
        }

        public string Contact
        {
            get;
            set;
        }

       

        public string idTrader
        {
            get;
            set;
        }

         public string Address
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Fax
        {
            get;
            set;
        }

        public string Segmentation
        {
            get;
            set;
        }

        public string TraderDocument
        {
            get;
            set;
        }

        public string TraderDocumentType
        {
            get;
            set;
        }

        public bool isProfesional
        {
            get;
            set;
        }


        public bool IsCertified
        {
            get;
            set;
        }

        public bool isDataserver
        {
            get;
            set;
        }

        /// Esta propiedad es establecida de acuerdo a la variable de configuracion <code>MostrarPreguntasSeguridad</code> que se encuentra en los servicios Web.
        public bool ShowSecurityQuestions
        {
            get;
            set;
        }

        public virtual IEnumerable<Enumerations.MarketType> ListMarket
        {
            get;
            set;
        }

       
        public List<string> UserInstruments //mobile
        {
            get;
            set;
        }

        public bool ShowTutorial
        {
            get;
            set;
        }
    }
}



