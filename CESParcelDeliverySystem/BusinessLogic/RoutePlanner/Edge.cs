using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.BusinessLogic.RoutePlanner
{
    public class Edge
    {
        private readonly int _v;
        private readonly int _w;
        private readonly double _cost;
        private readonly double _time;
        private readonly Type _type;

        public enum Type
        {
            Plane = 0,      // fly
            Truck = 1,      // truck
            Ship = 2        // boat
        }

        public Edge(int v, int w, double cost, double time, Type type)
        {
            this._v = v;
            this._w = w;
            this._cost = cost;
            this._time = time;
            this._type = type;
        }

        public double Cost()
        {
            return _cost;
        }

        public double Time()
        {
            return _time;
        }

        public int Source()
        {
            return _v;
        }

        public int Target(int vertex)
        {
            if (vertex == _v) return _w;
            else if (vertex == _w) return _v;
            else throw new Exception("Illegal endpoint");
        }

        public String toString()
        {
            return String.Format("{0:d}-{1:d} {2:f5}", _v, _w, _cost, _time);
        }
    }

}
