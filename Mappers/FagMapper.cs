using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarieSkema.DTO;
using MarieSkema.Models;

namespace MarieSkema.Mappers;

public static class FagMapper
{
    public static FagDTO GetFagDTO(Fag fag)
    {
        return new FagDTO
        {
            FagId = fag.FagId,
            FagNavn = fag.FagNavn,
            FagTid = fag.FagTid,
            TPTid = fag.TPTid
        };
    }

    public static Fag PostToFag(FagDTOPost fagDTOPost)
    {
        return new Fag
        {
            FagNavn = fagDTOPost.FagNavn,
            FagTid = fagDTOPost.FagTid,
            TPTid = fagDTOPost.TPTid
        };
    }
}