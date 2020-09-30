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
                bool isSameTypeOfSausage = false;
                int index = 0;
                for (int i = 0; i < _listOfSausages.Count; i++)
                {
                    if (_listOfSausages[i].TypeOfSausage == sausage.TypeOfSausage)
                    {
                        isSameTypeOfSausage = true;
                    }
                    if (isSameTypeOfSausage && _listOfSausages[i].TypeOfSausage != sausage.TypeOfSausage)
                    {
                        index = i;
                        break;
                    }
                }
                if (index == 0)
                {
                    index = _listOfSausages.Count;
                }
                _listOfSausages.Insert(index, sausage);
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
            foreach (Sausage sausage in _listOfSausages)
            {
                if (sausage.TypeOfSausage == sausageType)
                {
                    if (sausage.Weight > maxWeight)
                    {
                        sausage.Weight = sausage.Weight - maxWeight;
                        newSausage = new Sausage(sausageType, sausage.DateOfExpiry, weight);
                        break;
                    }
                    else if (sausage.Weight == maxWeight)
                    {
                        newSausage = new Sausage(sausageType, sausage.DateOfExpiry, weight);
                        _listOfSausages.Remove(sausage);
                        break;
                    }
                    else
                    {
                        if (isFirstSausage)
                        {
                            weight = weight - sausage.Weight;
                            newSausage = new Sausage(sausageType, sausage.DateOfExpiry, sausage.Weight);
                            _listOfSausages.Remove(sausage);

                            isFirstSausage = false;
                        }
                        else
                        {
                            if (weight > 0)
                            {
                                if (weight >= sausage.Weight)
                                {
                                    newSausage.Weight += sausage.Weight;
                                    weight -= sausage.Weight;
                                    _listOfSausages.Remove(sausage);
                                }
                                else
                                {
                                    newSausage.Weight += weight;
                                    sausage.Weight -= weight;
                                    weight = 0;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return newSausage;
        }

        public Sausage this[SausageType sausageType]
        {
            get
            {
                Sausage sausageToReturn = null;
                foreach (Sausage sausage in _listOfSausages)
                {
                    if (sausage.TypeOfSausage == sausageType)
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