using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace II_Shop.Data.Models {
    public class Order {

        [BindNever]
        public int id { get; set; }

        [MinLength(3, ErrorMessage = "The length of the {0} is less than {1} characters.")]
        public string name { get; set; }

        [MinLength(3, ErrorMessage = "The length of the {0} is less than {1} characters.")]
        public string surname { get; set; }

        [MinLength(7, ErrorMessage = "The length of the {0} is less than {1} characters.")]
        public string adress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [MinLength(7, ErrorMessage = "The length of the {0} is less than {1} characters.")]
        public string phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [MinLength(10, ErrorMessage = "The length of the {0} is less than {1} characters.")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }


    }
}
