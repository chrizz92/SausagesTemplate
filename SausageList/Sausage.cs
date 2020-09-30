using System;
using System.Runtime.Remoting.Messaging;

namespace Sausages
{
    /// <summary>
    /// Eine bestimmte Sausage mit Typ und Gewicht
    /// </summary>
    public class Sausage : IComparable
    {
        public enum SausageType { ExtraWurst, LeberKaese, EierWurst, Faschiertes };

        private double _weight;
        private DateTime _expireDate;
        private SausageType _sausageType;

        public Sausage(SausageType sausageType, DateTime expireDate, double weight)
        {
            Weight = weight;
            DateOfExpiry = expireDate;
            _sausageType = sausageType;
        }

        public SausageType TypeOfSausage
        {
            get
            {
                return _sausageType;
            }
            set
            {
                _sausageType = value;
            }
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

        public DateTime DateOfExpiry
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
            DateTime newDateOfExpiry;
            Sausage sausageToReturn;
            if (sausageOne.DateOfExpiry < sausageTwo.DateOfExpiry)
            {
                newDateOfExpiry = sausageOne.DateOfExpiry;
            }
            else
            {
                newDateOfExpiry = sausageTwo.DateOfExpiry;
            }

            if (sausageOne._sausageType == sausageTwo._sausageType)
            {
                sausageToReturn = new Sausage(sausageTwo._sausageType, newDateOfExpiry, sausageOne.Weight + sausageTwo.Weight);
            }
            else if (sausageOne._sausageType == SausageType.LeberKaese || sausageTwo._sausageType == SausageType.LeberKaese)
            {
                sausageToReturn = new Sausage(SausageType.LeberKaese, newDateOfExpiry, sausageOne.Weight + sausageTwo.Weight);
            }
            else
            {
                sausageToReturn = new Sausage(SausageType.Faschiertes, newDateOfExpiry, sausageOne.Weight + sausageTwo.Weight);
            }
            return sausageToReturn;
        }

        public int CompareTo(object obj)
        {
            if (this.Weight > (obj as Sausage).Weight)
            {
                return 1;
            }
            else if (this.Weight == (obj as Sausage).Weight)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}