using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarieSkema.Models;

public class Fag
{
    public int FagId { get; set; }
    public string FagNavn{ get; set; }
    public float FagTid { get; set; }
    public Boolean TPTid { get; set; }

    public ICollection<Laerer> laererses {get; set;} = new List<Laerer>();
    public ICollection<FagDage> fagDageses { get; set; } = new List<FagDage>();
}