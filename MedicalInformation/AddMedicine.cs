using System;

namespace Model
{
    public class AddMedicine
    {
        public string MedID { get; set; }
        public string MedName { get; set; }
        public string MedBarCode { get; set; } 
        public string Production { get; set; } 
        public DateTime InDate { get; set; } 
        public DateTime ProduteDate { get; set; }
        public DateTime DueDate { get; set; } 
        public int ReleaseDay { get; set; } 
        public int Quantity { get; set; } 
        public decimal MedBid { get; set; } 
        public decimal MedUnitPrice { get; set; } 
        public string Memary { get; set; }
    }
}
