﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;



namespace biz.matteria.Entities
{
    public partial class UsuariosRole
    {
        public int UsuarioId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual AuthUser Usuario { get; set; }
    }
}