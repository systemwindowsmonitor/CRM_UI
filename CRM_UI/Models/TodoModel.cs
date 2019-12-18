using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CRM_UI.Models
{
    class TodoModel
    {
        private string _vendorcode;
        public string vendorcode
        {
            get { return _vendorcode; }
            set { _vendorcode = value; }
        }
        //public Image image (string filename);
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        private string _Measurements;
        public string Measurements
        {
            get { return _Measurements; }
            set { _Measurements = value; }
        }
        private double _CostPrice;
        public double CostPrice
        {
            get { return _CostPrice; }
            set { _CostPrice = value; }
        }
        private double _Price;
        public double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        private double _Weight;
        public double Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
        private double _Volume;
        public double Volume
        {
            get { return _Volume; }
            set { _Volume = value; }
        }
        private string _Url;
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        private bool _InStock;
        public bool InStock
        {
            get { return _InStock; }
            set { _InStock = value; }
        }
        private string _Total;
        public string Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        //public string vendorcode { get; set; }
        private string _Irrelevant;
        public string Irrelevant
        {
            get { return _Irrelevant; }
            set { _Irrelevant = value; }
        }

        private string _Marketplace;
        public string Marketplace 
        {
            get { return _Marketplace; }
            set { _Marketplace = value; }
        }

        private bool _isDone;
        public bool IsDone
        {
            get { return _isDone; }
            set { _isDone = value; }
        }
    }
}
