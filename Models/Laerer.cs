using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarieSkema.Models;

public class Laerer
{
    public int LaererId { get; set; }
    public string LaererNavn { get; set; }

    public ICollection<FagDage> FagsDages { get; set; } = new List<FagDage> { };
}