﻿using Apuestas.DOMAIN.Core.Entities;

namespace Apuestas.DOMAIN.Core.Interface
{
    public interface IPromocionRepository
    {
        Task<bool> Delete(int id);
        Task<Promocion> GetPromocionById(int id);
        Task<IEnumerable<Promocion>> GetPromocion();
        Task<bool> Insert(Promocion promocion);
        Task<bool> Update(Promocion promocion);
    }
}