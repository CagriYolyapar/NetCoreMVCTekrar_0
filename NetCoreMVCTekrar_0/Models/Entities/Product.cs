﻿namespace NetCoreMVCTekrar_0.Models.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? Stocks { get; set; }
        public int? CategoryId { get; set; }

        //Relational Properties
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }



    }
}
