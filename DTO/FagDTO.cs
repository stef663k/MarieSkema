using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarieSkema.DTO;

public class FagDTO
{
    public int FagId { get; set; }
    public string FagNavn{ get; set; }
    public float FagTid { get; set; }
    public Boolean TPTid { get; set; }
}
public class FagDTOPost{
    public string FagNavn{ get; set; }
    public float FagTid{ get; set; }
    public Boolean TPTid{ get; set; }
}