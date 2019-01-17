﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Middleman.Domain.Domain
{
    public class Product
    {
        public Product()
        {
            ImagePath = "~/Content/Images/noImage.png";
        }
        #region Properties

        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(20, ErrorMessage = "The field {0} contains maximun {1} and minimun {2} characters", MinimumLength = 3)]
        [Display(Name ="Product name")]
        public string ProductName { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        #endregion

        #region Navigation properties
        public virtual Category Category { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }


        #endregion
    }
}