using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfPlacing { get; set; }
        public List<UserDTO> Users { get; set; }

        public ProductDTO()
        {
            Users = new List<UserDTO>();
        }
    }
}