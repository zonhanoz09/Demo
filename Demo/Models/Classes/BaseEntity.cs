using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Demo.Models.Classes
{
    public interface IEntity
    {
        DateTime ? LastUpdated { get; set; }

        int ? LastUpdatedBy { get; set; }
    }
    public abstract class BaseEntity : IEntity
    {
        public DateTime ? LastUpdated { get; set; }

        public int ? LastUpdatedBy { get; set; }
    }
}