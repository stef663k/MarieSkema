using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarieSkema.Models;

public class FagDage
{
    public int FagDageId { get; set; }
    public enum Dage{
        Mandag,
        Tirsdag,
        Onsdag,
        Torsdag,
        Fredag
    }   
    public Dage Dag { get; set; }
    public DateTime dateTime{ get; set; }


    public ICollection<Laerer> laerers { get; set; } = new List<Laerer>();
    public ICollection<Fag> fag { get; set; } = new List<Fag>();
}