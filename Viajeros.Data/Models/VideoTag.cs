﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viajeros.Data.Models
{
    public class VideoTag
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Video")]
        public int VideoID { get; set; }
        public Video Video { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}