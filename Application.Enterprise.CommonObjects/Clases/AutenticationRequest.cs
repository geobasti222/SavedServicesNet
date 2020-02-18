using System;

namespace Application.Enterprise.CommonObjects
{
    public class AutenticationRequest
    {
        public AutenticationRequest()
        {
            //Perfil = CommonObjects.PerfilUsuario.Ordenante;
        }
        public virtual string strIdUser
        {
            get;
            set;
        }

        public virtual string strPassword
        {
            get;
            set;
        }

        public virtual string strNewPassword
        {
            get;
            set;
        }

        public virtual string strIdClient
        {
            get;
            set;
        }

        public virtual string StrMnemonic
        {
            get;
            set;
        }

        public virtual int intMarkett
        {
            get;
            set;
        }

        public virtual DateTime dtmDate
        {
            get;
            set;
        }

        public virtual DateTime dtmInitialDate
        {
            get;
            set;
        }

        public virtual DateTime dtmFinalDate
        {
            get;
            set;
        }

        public virtual string strAccDeceval
        {
            get;
            set;
        }

        public virtual string strTransactionType
        {
            get;
            set;
        }

        public virtual string Token
        {
            get;
            set;
        }

        public virtual int intSegmentType
        {
            get;
            set;
        }

        public virtual bool  forceLogin
        {
            get;
            set;
        }

        public virtual bool ValidateIPAddress
        {
            get;
            set;
        }

        public virtual int ID
        {
            get;
            set;
        }

        public virtual string Profile
        {
            get;
            set;
        }

        public virtual bool UseHashing
        {
            get;
            set;
        }

        public virtual string DocumentType
        {
            get;
            set;
        }

        public virtual int AccountNumber
        {
            get;
            set;
        }

        public virtual bool Disclaimer
        {
            get;
            set;
        }


        public virtual int Periodicity
        {
            get;
            set;
        }

        public virtual int Interval
        {
            get;
            set;
        }

        public virtual int NumRegister
        {
            get;
            set;
        }


        public virtual bool DataServer
        {
            get;
            set;
        }

        public virtual bool CustomBool
        {
            get;
            set;
        }

        //public CommonObjects.PerfilUsuario Perfil { get; set; }

    }
}
