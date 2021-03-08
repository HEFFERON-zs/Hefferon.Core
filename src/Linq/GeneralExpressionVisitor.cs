using System.Collections.Generic;
using System.Linq.Expressions;

namespace Hefferon.Core.Linq
{
    /// <summary>
    /// General implementation of <see cref="ExpressionVisitor"/>. ExpressionVisitors makes possible of traversing, examining or copying an expression tree.
    /// </summary>
    public class GeneralExpressionVisitor : ExpressionVisitor
    {
        #region Fields

        private readonly Dictionary<ParameterExpression, ParameterExpression> _map;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Initializes new instance of <see cref="GeneralExpressionVisitor"/> class.
        /// </summary>
        /// <param name="map">Parameters map.</param>
        private GeneralExpressionVisitor(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            _map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Replaces parameters.
        /// </summary>
        /// <param name="map">Parameters map.</param>
        /// <param name="exp">Expression.</param>
        /// <returns>The modified expression.</returns>
        internal static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new GeneralExpressionVisitor(map).Visit(exp);
        }

        /// <summary>
        /// Visits the <see cref="ParameterExpression"/>.
        /// </summary>
        /// <param name="node">The expression to visit.</param>
        /// <returns>The modified expression, if it or any subexpression was modified; otherwise, returns the original expression.</returns>
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (_map.TryGetValue(node, out ParameterExpression replacement))
            {
                node = replacement;
            }

            return base.VisitParameter(node);
        }

        #endregion // Methods
    }
}