using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarieSkema.DTO;
using MarieSkema.Models;

namespace MarieSkema.Mappers;

public class LaererMapper
{
    public static LaererDTO laererDTOMapper(Laerer laerer)
    {
        return new LaererDTO
        {
            LaererId = laerer.LaererId,
            LaererNavn = laerer.LaererNavn
        };
    } 


    public static Laerer LæarerPostMapper(LaererDTO dto)
    {
        return new Laerer
        {
            LaererId = dto.LaererId,
            LaererNavn = dto.LaererNavn
        };
    }
}