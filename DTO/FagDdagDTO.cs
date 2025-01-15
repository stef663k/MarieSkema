using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarieSkema.Models;
using NuGet.Versioning;

namespace MarieSkema.DTO;

public class FagDdagDTO
{
    public int FagDdageId { get; set; }
    public Dage Dag { get; set; }
    public DateTime dateTime { get; set; }
    public int FagId { get; set; }
    public int LaererId { get; set; }
    public float TPTimer { get; set; }
    public float FagFagligeTimer { get; set; }
}

public class FagDdagDTOPost 
{
    public Dage Dag { get; set; }
    public DateTime dateTime { get; set; }
    public int FagId { get; set; }
    public int LaererId { get; set;}
    public float TPTimer { get; set;}
    public float FagFagligeTimer { get; set; }
}