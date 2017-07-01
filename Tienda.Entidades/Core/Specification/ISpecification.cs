using System;
using System.Linq.Expressions;

namespace Tienda.Entidades.Core.Specification
{
    public interface ISpecification<E>
    {
        Func<E, bool> EvalFunc { get; }
        Expression<Func<E, bool>> EvalPredicate { get; }
    }
}
