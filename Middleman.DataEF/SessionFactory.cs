using Middleman.Data;

namespace Middleman.DataEF
{
    public class SessionFactory : ISessionFactory
    {
        private IUnitOfWork uow;

        #region ISessionFactory Members

        /// <summary>
        /// Gets the current uow.
        /// </summary>
        /// <value>The current uow.</value>
        public IUnitOfWork CurrentUoW
        {
            get
            {
                if (uow == null)
                {
                    uow = GetUnitOfWork();
                }

                return uow;
            }
        }

        #endregion

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <returns></returns>
        private IUnitOfWork GetUnitOfWork()
        {
            var orm = new MiddlemanContext();
            return new UnitOfWork(orm);
        }
    }

}
