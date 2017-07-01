using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Tienda.Entidades.Core.Modelos;

namespace Tienda.Entidades.Core.Specification
{
    public static class Utility
    {
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);
            // apply composition of lambda expression bodies to parameters from the first expression 
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose<Func<T, bool>>(second, new Func<Expression, Expression, Expression>(Expression.And));
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose<Func<T, bool>>(second, new Func<Expression, Expression, Expression>(Expression.Or));
        }

        public static Busqueda Paginar<T>(this IEnumerable<T> elements, int page, int pageSize)
        {
            if (elements == null)
                return new Busqueda();
            IList<T> source1 = elements as IList<T> ?? (IList<T>)elements.ToList<T>();
            Decimal count = (Decimal)source1.Count;
            IEnumerable<T> source2 = source1.Skip<T>((page - 1) * pageSize).Take<T>(pageSize);
            IList<T> source3 = source2 as IList<T> ?? (IList<T>)source2.ToList<T>();
            Decimal num1 = pageSize > 0 ? Math.Ceiling(count / (Decimal)pageSize) : Decimal.Zero;
            Busqueda busqueda1 = new Busqueda();
            busqueda1.PaginaActual = page;
            int num2 = (int)num1;
            busqueda1.TotalPagina = num2;
            IList<T> objList = source3;
            busqueda1.Items = (IEnumerable)objList;
            int num3 = (int)count;
            busqueda1.TotalRegistros = num3;
            Busqueda busqueda2 = busqueda1;
            if (source3.Any<T>() && busqueda2.TotalPagina == 0)
                busqueda2.TotalPagina = 1;
            if (!source3.Any<T>())
                busqueda2.PaginaActual = 0;
            return busqueda2;
        }
    }
}
