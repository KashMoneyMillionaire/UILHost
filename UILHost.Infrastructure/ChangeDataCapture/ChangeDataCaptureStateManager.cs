using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using UILHost.Infrastructure.ChangeDataCapture;
using UILHost.Infrastructure.Data.Patterns;
using UILHost.Infrastructure.Domain;
using UILHost.Infrastructure.Entity;
using Common.Logging;
using UILHost.Infrastructure.ChangeDataCapture;
using UILHost.Infrastructure.Entity;

namespace UILHost.Infrastructure.ChangeDataCapture
{
    public class ChangeDataCaptureStateManager
    {
        private readonly Func<string> _getCurrentUserNameFunc;
        private readonly Func<string> _getRequestIpAddressFunc;
        private readonly Func<string> _getCurrentSessionIdFunc;

        private readonly ILog _log = LogManager.GetLogger(typeof(ChangeDataCaptureStateManager));

        public List<Infrastructure.ChangeDataCapture.ChangeDataCaptureEntityState> EntityStateList { get; private set;  }

        public ChangeDataCaptureStateManager(
            Func<string> getCurrentUserNameFunc,
            Func<string> getRequestIpAddressFunc,
            Func<string> getCurrentSessionIdFunc)
        {
            _getCurrentUserNameFunc = getCurrentUserNameFunc;
            _getRequestIpAddressFunc = getRequestIpAddressFunc;
            _getCurrentSessionIdFunc = getCurrentSessionIdFunc;
            EntityStateList = new List<ChangeDataCaptureEntityState>();
        }

        public bool HasChanges()
        {
            return this.EntityStateList.Any(s => s.HasChanges());
        }

        public void LogChanges(DbContext context, Patterns.Repository.EF6.Entity entity, Infrastructure.ChangeDataCapture.ChangeDataCaptureEntityStatus status)
        {
            if (!AppConfigFacade.DoChangeDataCapture)
                return;

            // get entry

            var entry = context.ChangeTracker.Entries().FirstOrDefault(e => e.Entity.Equals(entity));

            if (entry == null)
                throw new InvalidOperationException(
                    string.Format("Could not find change tracker entry for entity {0}", entity.GetType().Name));

            if (entry.State == EntityState.Detached)
                throw new InvalidOperationException(string.Format("Cannot audit changes for {0} for entity type {1}",
                    EntityState.Detached,
                    entity.GetType()));

            if (entry.State == EntityState.Unchanged)
                return;

            // get entity type

            Type entityType = entity.GetType();

            if (entityType.GetCustomAttribute<HideFromChangeDataCaptureAttribute>() != null)
                return;

            if (entityType.BaseType.GetGenericTypeDefinition() != typeof (EntityBase<>))
                throw new ArgumentException(string.Format("Entity type {0} must extend {1}",
                    entity.GetType(),
                    typeof (EntityBase<>)));

            lock (this.EntityStateList)
            {
                // get existing entity state or create new

                bool isNewEntry = true;

                if (!EntityStateList.Any(e => e.Entity.Equals(entity)))
                    EntityStateList.Add(new ChangeDataCaptureEntityState(entity, status));
                else
                    isNewEntry = false;

                var entityState = EntityStateList.FirstOrDefault(e => e.Entity.Equals(entity));

                // generate property states if not already exists

                foreach (var propertyName in entry.State == EntityState.Deleted
                    ? entry.OriginalValues.PropertyNames
                    : entry.CurrentValues.PropertyNames)
                {
                    if (
                        !entityState.PropertyStates.Any(
                            s => s.PropertyName.Equals(propertyName, StringComparison.OrdinalIgnoreCase)))
                        entityState.PropertyStates.Add(
                            new Infrastructure.ChangeDataCapture.ChangeDataCapturePropertyState(propertyName));
                }

                // update entity status

                switch (entry.State)
                {
                    case EntityState.Added:
                        entityState.Status = Infrastructure.ChangeDataCapture.ChangeDataCaptureEntityStatus.New;
                        break;
                    case EntityState.Deleted:
                        entityState.Status =
                            Infrastructure.ChangeDataCapture.ChangeDataCaptureEntityStatus.Deleted;
                        break;
                    case EntityState.Modified:
                        entityState.Status =
                            Infrastructure.ChangeDataCapture.ChangeDataCaptureEntityStatus.Updated;
                        break;
                    default:
                        throw new Exception(string.Format("EntityState '{0}' is not defined for this switch",
                            entry.State));
                }

                // update property states

                foreach (var propertyName in entry.State == EntityState.Deleted
                    ? entry.OriginalValues.PropertyNames
                    : entry.CurrentValues.PropertyNames)
                {

                    var propertyState =
                        entityState.PropertyStates.FirstOrDefault(
                            s => s.PropertyName.Equals(propertyName, StringComparison.OrdinalIgnoreCase));

                    // ReSharper disable once PossibleNullReferenceException
                    if (entry.State != EntityState.Deleted)
                        propertyState.CurrentValue = entry.CurrentValues[propertyName];

                    if (entry.State != EntityState.Added
                        && isNewEntry)
                        propertyState.OriginalValue = entry.OriginalValues[propertyName];
                }

            }

        }

        public void CommitState(UnitOfWorkExt uow)
        {
            if (!AppConfigFacade.DoChangeDataCapture)
                return;

            try
            {

                ChangeDataAudit audit = null;

                if (this.HasChanges())
                {
                    audit = new ChangeDataAudit("", "", this._getCurrentUserNameFunc == null
                        ? null
                        : this._getCurrentUserNameFunc());

                    uow.Repository<ChangeDataAudit>().Insert(audit);

                    foreach (var entityState
                        in this.EntityStateList.Where(e => e.HasChanges()))
                    {
                        var type = entityState.Entity.GetType().FullName;
                        var id = entityState.Entity.GetType().GetProperty("Id").GetValue(entityState.Entity).ToString();

                        foreach (var propertyState in entityState.PropertyStates.Where(p => p.HasChanges()))
                        {
                            var detail = new ChangeDataAuditDetail()
                            {
                                EntityType = type,
                                EntityId = id,
                                Property = propertyState.PropertyName,
                                NewValue =
                                    propertyState.CurrentValue == null
                                        ? null
                                        : propertyState.CurrentValue.ToString(),
                                OldValue =
                                    propertyState.OriginalValue == null
                                        ? null
                                        : propertyState.OriginalValue.ToString()
                            };

                            audit.Details.Add(detail);
                            uow.Repository<ChangeDataAuditDetail>().Insert(detail);
                        }
                    }                  
                }

                this.EntityStateList.Clear();

                if (audit != null)
                    uow.SaveChanges();
            
            }
            catch (Exception ex)
            {
                this._log.ErrorFormat("An error occured during change data capture", ex);
            }
            
        }

    }
}
