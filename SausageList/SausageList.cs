using System;
using System.Collections.Generic;

namespace Sausages
{
    public class SausageList
    {
        private List<Sausage> _listOfSausages;

        public double WeightOfAllSausages
        {
            get
            {
                double sumOfWeights = 0.0;
                foreach (Sausage sausage in _listOfSausages)
                {
                    sumOfWeights += sausage.Weight;
                }
                return sumOfWeights;
            }
        }

        public int Count
        {
            get
            {
                return _listOfSausages.Count;
            }
        }

        public SausageList()
        {
            _listOfSausages = new List<Sausage>();
        }

        public int GetPos(Sausage sausage)
        {
            int position = -1;
            if (_listOfSausages.Contains(sausage))
            {
                position = _listOfSausages.IndexOf(sausage);
            }
            return position;
        }

        public void Add(Sausage sausage)
        {
            if (_listOfSausages.Count == 0)
            {
                _listOfSausages.Add(sausage);
            }
            else
            {
                foreach (Sausage sausageInList in _listOfSausages)
                {
                    if (sausage.SausageType < sausageInList.SausageType)
                    {
                        _listOfSausages.Insert(_listOfSausages.IndexOf(sausageInList), sausage);
                        return;
                    }
                }
                _listOfSausages.Add(sausage);
            }
        }

        public void RemoveSausageOnPosition(int position)
        {
            _listOfSausages.RemoveAt(position);
        }

        public Sausage CutFromSausage(SausageType sausageType, double weight)
        {
            Sausage newSausage = null;
            double maxWeight = weight;
            bool isFirstSausage = true;

            do
            {
                if (isFirstSausage)
                {
                    foreach (Sausage sausage in _listOfSausages)
                    {
                        if (sausage.SausageType == sausageType)
                        {
                            if (sausage.Weight > weight)
                            {
                                newSausage = new Sausage(sausageType, sausage.DateOfExpiry, weight);
                                sausage.Weight -= weight;
                                weight = 0.0;
                                isFirstSausage = false;
                            }
                            else
                            {
                                newSausage = new Sausage(sausageType, sausage.DateOfExpiry, sausage.Weight);
                                weight -= sausage.Weight;
                                sausage.Weight = 0.0;
                                isFirstSausage = false;
                            }
                            break;
                        }
                    }
                    if (isFirstSausage)
                    {
                        break;
                    }
                }
                else
                {
                    foreach (Sausage sausage in _listOfSausages)
                    {
                        if (weight <= 0.001)
                        {
                            break;
                        }
                        if (sausage.SausageType == sausageType)
                        {
                            if (sausage.Weight > weight)
                            {
                                newSausage.Weight += weight;
                                sausage.Weight -= weight;
                                weight = 0.0;
                            }
                            else
                            {
                                newSausage.Weight += sausage.Weight;
                                weight -= sausage.Weight;
                                sausage.Weight = 0.0;
                            }
                        }
                    }
                    break;
                }
                for (int i = _listOfSausages.Count - 1; i >= 0; i--)
                {
                    if (_listOfSausages[i].Weight <= 0.001)
                    {
                        _listOfSausages.RemoveAt(i);
                    }
                }
            } while (weight > 0.001);

            return newSausage;
        }

        public Sausage this[SausageType sausageType]
        {
            get
            {
                Sausage sausageToReturn = null;
                foreach (Sausage sausage in _listOfSausages)
                {
                    if (sausage.SausageType == sausageType)
                    {
                        sausageToReturn = sausage;
                        break;
                    }
                }
                return sausageToReturn;
            }
        }

        public Sausage this[int index]
        {
            get
            {
                return _listOfSausages[index];
            }
        }
    }
}