﻿using System.Collections.Generic;
using System.Linq.Expressions;

namespace Tienda.Entidades.Core.Specification
{
    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression parameterExpression;
            if (this.map.TryGetValue(p, out parameterExpression))
                p = parameterExpression;
            return base.VisitParameter(p);
        }
    }
}
