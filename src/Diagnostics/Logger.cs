
namespace Hefferon.Core.Diagnostics
{
    /// <summary>
    /// Provides the abstract base class for the <see cref="Logger"/> types.
    /// </summary>
    public abstract class Logger
    {
        #region Methods

        /// <summary>
        /// Replaces in specified array all <c>null</c> values with string representation of <c>null</c> value.
        /// </summary>
        /// <param name="args">Format arguments.</param>
        /// <returns>Specified array with replaced <c>null</c> values.</returns>
        protected static object[] ReplaceNullsWithStrings(object[] args)
        {
            if (args == null)
                return null;

            for (int i = 1; i < args.Length; i++)
                args[i] = args[i] ?? "<null>";

            return args;
        }

        #endregion
    }
}