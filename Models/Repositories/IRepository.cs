using System;
using System.Collections.Generic;

namespace AcademicRegistry.Models.Repositories;

public interface IRepository<T>
{
    bool Add(T element);

    T? GetBy(Guid id);

    IEnumerable<T> GetAll();

    bool Update(T element);

    bool Delete(T element);
}