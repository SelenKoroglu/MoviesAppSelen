﻿using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="User Name is required!")]
        [StringLength(20, ErrorMessage ="User Name must be maximum {1} characters!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [StringLength(10, ErrorMessage = "Password must be maximum {1} characters!")]
        public string Password { get; set; }    

        public bool IsActive { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

    }
}
