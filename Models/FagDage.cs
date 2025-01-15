using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarieSkema.Models;

public enum Dage{
    Mandag,
    Tirsdag,
    Onsdag,
    Torsdag,
    Fredag,
    Lørdag,
    Søndag
} 
public class FagDage
{
    public int FagDageId { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public Dage Dag { get; set; }
    public DateTime dateTime{ get; set; }

    public int FagId { get; set; }
    public int LaererId { get; set; }

    public float TPTimer { get; set; }
    public float FagFagligeTimer { get; set; }

    public Fag Fag { get; set; }
    public Laerer Laerer{ get; set; }


}