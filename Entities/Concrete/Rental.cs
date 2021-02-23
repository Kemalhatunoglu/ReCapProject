using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        
        public DateTime? RentDate { get; set; }
        
        public DateTime? ReturnDate { get; set; }

        public virtual List<Car> Cars { get; set; }
        public virtual Customer Customer { get; set; }


    }
}
