using System;
using System.Linq.Expressions;

namespace Tienda.Entidades.Core.Specification
{
    public class Specification<E> : ISpecification<E>
    {
        private Func<E, bool> _evalFunc = (Func<E, bool>)null;
        private Expression<Func<E, bool>> _evalPredicate;

        public virtual Expression<Func<E, bool>> EvalPredicate
        {
            get
            {
                return this._evalPredicate;
            }
        }

        public virtual Func<E, bool> EvalFunc
        {
            get
            {
                return this._evalPredicate != null ? this._evalPredicate.Compile() : (Func<E, bool>)null;
            }
        }

        public Specification(Expression<Func<E, bool>> predicate)
        {
            this._evalPredicate = predicate;
        }

        private Specification()
        {
        }

        public static Specification<E> operator &(Specification<E> left, ISpecification<E> right)
        {
            return (Specification<E>)new Specification<E>.AndSpecification((ISpecification<E>)left, right);
        }

        public static Specification<E> operator |(Specification<E> left, ISpecification<E> right)
        {
            return (Specification<E>)new Specification<E>.OrSpecification((ISpecification<E>)left, right);
        }

        public virtual bool Matches(E entity)
        {
            return this._evalPredicate.Compile()(entity);
        }

        private class AndSpecification : Specification<E>
        {
            private readonly ISpecification<E> _left;
            private readonly ISpecification<E> _right;

            public AndSpecification(ISpecification<E> left, ISpecification<E> right)
            {
                this._left = left;
                this._right = right;
                this._evalFunc = left.EvalPredicate.Compile() + right.EvalPredicate.Compile();
                this._evalPredicate = left.EvalPredicate.And<E>(right.EvalPredicate);
            }

            public override bool Matches(E entity)
            {
                return this.EvalPredicate.Compile()(entity);
            }
        }

        private class OrSpecification : Specification<E>
        {
            private readonly ISpecification<E> _left;
            private readonly ISpecification<E> _right;

            public OrSpecification(ISpecification<E> left, ISpecification<E> right)
            {
                this._left = left;
                this._right = right;
                this._evalFunc = left.EvalPredicate.Compile() + right.EvalPredicate.Compile();
                this._evalPredicate = left.EvalPredicate.Or<E>(right.EvalPredicate);
            }

            public override bool Matches(E entity)
            {
                return this.EvalPredicate.Compile()(entity);
            }
        }
    }
}
