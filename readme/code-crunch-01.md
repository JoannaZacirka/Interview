##### What is return type of OnOccured? 
##### What is this method for? Try to guess
```
public (???) OnOccured(IEventTransaction transaction, IEventsSack allFromTransaction)
        {
            return allFromTransaction.Get<VhRecordChangedWithHeadVerificationEvent>()
                .Where(HasStateChanged)
                .Select(vhRecordChangedWithHeadVerificationEvent => ToVhReportedStateChanged(allFromTransaction, vhRecordChangedWithHeadVerificationEvent))
                .Concat(
                    allFromTransaction.Get<VhNotificationRecordChangedWithHeadVerificationEvent>()
                        .Where(HasStateChanged)
                        .Select(vhNotificationRecordChangedWithHeadVerificationEvent =>ToVhReportedStateChanged(allFromTransaction, vhNotificationRecordChangedWithHeadVerificationEvent))
                ).Where(CanCreatedStateBePublished).ToList();
        }

private static bool HasStateChanged(VhRecordChangedWithHeadVerificationEvent changeEvent);
private VhReportedStateChangedEvent ToVhReportedStateChanged(IEventsSack allFromTransaction, VhRecordChangedWithHeadVerificationEvent changeEvent);
private VhReportedStateChangedEvent ToVhReportedStateChanged(IEventsSack allFromTransaction, VhNotificationRecordChangedWithHeadVerificationEvent changeEvent)
private bool CanCreatedStateBePublished(VhReportedStateChangedEvent vhReportedStateChangedEvent);

```


