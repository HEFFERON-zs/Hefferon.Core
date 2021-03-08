using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Hefferon.Core.Linq
{
    /// <summary>
    /// Provides extension methods for Expression&lt;Func&lt;T, bool&gt;&gt;.
    /// </summary>
    public static class ExpressionExtensions
    {
        #region Methods

        /// <summary>
        /// Composes expression by combining <paramref name="first"/> and <paramref name="second "/> expressions 
        /// with <paramref name="merge"/> represents binary expression.
        /// </summary>
        /// <typeparam name="T">Type of the elements of the source.</typeparam>
        /// <param name="first">First expression.</param>
        /// <param name="second">Second expression.</param>
        /// <param name="merge">Binary expression.</param>
        /// <returns>
        /// Combined expressions <paramref name="first"/> and <paramref name="second "/> with <paramref name="merge"/> binary expression.
        /// </returns>
        private static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
            var secondBody = GeneralExpressionVisitor.ReplaceParameters(map, second.Body);

            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        /// <summary>
        /// Composes expression by combining <paramref name="first"/> and <paramref name="second "/> expressions
        /// with binary expression that represents a bitwise AND operation.
        /// </summary>
        /// <typeparam name="T">Type of the elements of the source.</typeparam>
        /// <param name="first">First expression.</param>
        /// <param name="second">Second expression.</param>
        /// <returns>
        /// Combined expressions <paramref name="first"/> and <paramref name="second "/> with bitwise AND binary expression.
        /// </returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        /// <summary>
        /// Composes expression by combining <paramref name="first"/> and <paramref name="second "/> expressions
        /// with binary expression that represents a bitwise ANDALSO operation.
        /// </summary>
        /// <typeparam name="T">Type of the elements of the source.</typeparam>
        /// <param name="first">First expression.</param>
        /// <param name="second">Second expression.</param>
        /// <returns>
        /// Combined expressions <paramref name="first"/> and <paramref name="second "/> with bitwise ANDALSO binary expression.
        /// </returns>
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.AndAlso);
        }

        /// <summary>
        /// Composes expression by combining <paramref name="first"/> and <paramref name="second "/> expressions
        /// with binary expression that represents a bitwise OR operation.
        /// </summary>
        /// <typeparam name="T">Type of the elements of the source.</typeparam>
        /// <param name="first">First expression.</param>
        /// <param name="second">Second expression.</param>
        /// <returns>
        /// Combined expressions <paramref name="first"/> and <paramref name="second "/> with bitwise OR binary expression.
        /// </returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }

        /// <summary>
        /// Extracts the property name from a <paramref name="propertyExpression"/>.
        /// </summary>
        /// <typeparam name="T">The object type containing the property specified in the expression.</typeparam>
        /// <param name="propertyExpression">The property expression (e.g. p => p.PropertyName)</param>
        /// <returns>The name of the property.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="propertyExpression"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the expression is:<br/>
        ///     Not a <see cref="MemberExpression"/><br/>
        ///     The <see cref="MemberExpression"/> does not represent a property.<br/>
        ///     Or, the property is static.
        /// </exception>
        public static string GetPropertyName<T>(this Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException("propertyExpression");
            }

            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("propertyExpression");
            }

            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
            {
                throw new ArgumentException("propertyExpression");
            }

            var getMethod = property.GetMethod;
            if (getMethod.IsStatic)
            {
                throw new ArgumentException("propertyExpression");
            }

            return memberExpression.Member.Name;
        }

        #endregion // Methods
    }
}