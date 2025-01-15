using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarieSkema.DTO;
using MarieSkema.Models;

namespace MarieSkema.Mappers;

public class FagDagMapper
{
    public static FagDdagDTO fagDdagDTOGETMapper(FagDage fagDage)
    {
        return new FagDdagDTO
        {
            FagDdageId = fagDage.FagDageId,
            Dag = fagDage.Dag,
            dateTime = fagDage.dateTime,
            FagId = fagDage.FagId,
            LaererId = fagDage.LaererId,
            TPTimer = fagDage.TPTimer,
            FagFagligeTimer = fagDage.FagFagligeTimer
        };
    }

    public static FagDage fagDdagDTOPOSTMapper(FagDdagDTO dto)
    {
        return new FagDage
        {
            Dag = dto.Dag,
            dateTime = dto.dateTime,
            FagId = dto.FagId,
            LaererId = dto.LaererId,
            TPTimer = dto.TPTimer,
            FagFagligeTimer = dto.FagFagligeTimer
        };
    }
}