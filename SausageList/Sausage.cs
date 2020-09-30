using System;

namespace Sausages
{
    /// <summary>
    /// Eine bestimmte Sausage mit Typ und Gewicht
    /// </summary>
    public class Sausage
    {
        public enum SausageTypes { ExtraWurst, LeberKaese, EierWurst, Faschiertes };

        private double _weight;
        private DateTime _expireDate;
        private SausageTypes _sausageType;

        public Sausage(SausageTypes sausageType, double weight, DateTime expireDate)
        {
            Weight = weight;
            _expireDate = expireDate;
            _sausageType = sausageType;
        }

        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }

        public DateTime ExpireDate
        {
            get
            {
                return _expireDate;
            }
            set
            {
                _expireDate = value;
            }
        }

        public static Sausage operator +(Sausage sausageOne, Sausage sausageTwo)
        {
            if (sausageOne._sausageType == sausageTwo._sausageType)
            {
                throw new NotImplementedException();
            }
            else if (sausageOne._sausageType == SausageTypes.LeberKaese || sausageTwo._sausageType == SausageTypes.LeberKaese)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}