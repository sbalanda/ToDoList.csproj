using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList
{
    public interface IEntry
    {
        int EntryId { get; set; }
        int UserId { get; set; }
        long Timestamp { get; set; }
    }

    public class AddedEntry : IEntry
    {
        public int EntryId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public long Timestamp { get; set; }
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj) => obj?.ToString() == ToString();
        public override string ToString() => $"{EntryId} {UserId} {Name} {Timestamp}";
    }

    public class RemovedEntry : IEntry
    {
        public int EntryId { get; set; }
        public int UserId { get; set; }
        public long Timestamp { get; set; }
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj) => obj?.ToString() == ToString();
        public override string ToString() => $"{EntryId} {UserId} {Timestamp}";
    }

    public class MarkedEntry : IEntry
    {
        public int EntryId { get; set; }
        public int UserId { get; set; }
        public long Timestamp { get; set; }
        public EntryState State { get; set; }
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj) => obj?.ToString() == ToString();
        public override string ToString() => $"{EntryId} {UserId} {Timestamp} {State}";
    }

    public class ToDoList : IToDoList
    {
        private List<Entry> entries = new List<Entry>();
        private readonly HashSet<int> removedUserIds = new HashSet<int>();
        private readonly HashSet<AddedEntry> addedEntries = new HashSet<AddedEntry>();
        private readonly HashSet<RemovedEntry> removedEntries = new HashSet<RemovedEntry>();
        private readonly HashSet<MarkedEntry> markedEntries = new HashSet<MarkedEntry>();
        private List<AddedEntry> addedEntriesIsAllowedAfterRemoval = new List<AddedEntry>();

        public int Count => entries.Count;

        public void AddEntry(int entryId, int userId, string name, long timestamp)
        {
            addedEntries.Add(new AddedEntry
            {
                EntryId = entryId,
                UserId = userId,
                Name = name,
                Timestamp = timestamp
            });

            if (IsUserIdAllowed(userId) && !IsEntryRemoved(entryId, timestamp))
            {
                addedEntriesIsAllowedAfterRemoval.Add(addedEntries.Last());
                UpdateEntries();
            }
        }

        public void RemoveEntry(int entryId, int userId, long timestamp)
        {
            removedEntries.Add(new RemovedEntry
            {
                EntryId = entryId,
                UserId = userId,
                Timestamp = timestamp
            });
            addedEntriesIsAllowedAfterRemoval.RemoveAll(e => e.EntryId == entryId && e.Timestamp <= timestamp);
            UpdateEntries();
        }

        public void MarkDone(int entryId, int userId, long timestamp)
        {
            markedEntries.Add(new MarkedEntry
            {
                EntryId = entryId,
                UserId = userId,
                Timestamp = timestamp,
                State = EntryState.Done
            });
            UpdateEntryState(entryId);
        }

        public void MarkUndone(int entryId, int userId, long timestamp)
        {
            markedEntries.Add(new MarkedEntry
            {
                EntryId = entryId,
                UserId = userId,
                Timestamp = timestamp,
                State = EntryState.Undone
            });
            UpdateEntryState(entryId);
        }

        public void DismissUser(int userId)
        {
            removedUserIds.Add(userId);
            addedEntriesIsAllowedAfterRemoval.RemoveAll(u => u.UserId == userId);
            UpdateEntries();
        }

        public void AllowUser(int userId)
        {
            removedUserIds.Remove(userId);
            var addedEntriesUserIdIsAllowed = GetEntriesUserIdIsAllowed(addedEntries);
            var removedEntriesUserIdIsAllowed = GetEntriesUserIdIsAllowed(removedEntries);
            addedEntriesIsAllowedAfterRemoval =
                GetEntriesAfterRemoval(addedEntriesUserIdIsAllowed, removedEntriesUserIdIsAllowed);
            UpdateEntries();
        }

        public IEnumerator<Entry> GetEnumerator()
        {
            return entries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void UpdateEntries()
        {
            entries.Clear();

            var groupedAddedEntries = GroupEntriesByEntryIdOrderByTime(addedEntriesIsAllowedAfterRemoval);

            foreach (var groupedAddedEntry in groupedAddedEntries)
            {
                var outputEntryId = groupedAddedEntry.Key;
                var outputName = GetEntryName(groupedAddedEntry.ToList());
                var outputState = GetEntryState(outputEntryId);
                entries.Add(new Entry(outputEntryId, outputName, outputState));
            }

        }

        private string GetEntryName(IReadOnlyCollection<AddedEntry> groupedEntries)
        {
            if (groupedEntries.Count == 1)
                return groupedEntries.First().Name;

            var entriesWithMaxTime = groupedEntries
                .Where(p => p.Timestamp == groupedEntries.First().Timestamp);
            return entriesWithMaxTime.OrderBy(p => p.UserId).First().Name;
        }

        private EntryState GetEntryState(int inputEntryId)
        {
            if (!markedEntries.Any()) return EntryState.Undone;

            var markedEntryUserIdIsAllowed = GetEntriesUserIdIsAllowed(markedEntries);
            var markedEntryUserIdIsAllowedWithEntryId = markedEntryUserIdIsAllowed
                .Where(o => o.EntryId == inputEntryId)
                .ToList();

            switch (markedEntryUserIdIsAllowedWithEntryId.Count)
            {
                case 0:
                    return EntryState.Undone;
                case 1:
                    return markedEntryUserIdIsAllowedWithEntryId.First().State;
            }

            var maxTimestamp = markedEntryUserIdIsAllowedWithEntryId.Max(p => p.Timestamp);
            var entriesWithMaxTimestamp = markedEntryUserIdIsAllowedWithEntryId.Where(p => p.Timestamp == maxTimestamp).ToList();

            var outputState = entriesWithMaxTimestamp.Count == 1
                ? entriesWithMaxTimestamp.First().State
                : markedEntryUserIdIsAllowedWithEntryId.OrderBy(p => p.State).First().State;

            return outputState;
        }

        private void UpdateEntryState(int entryId)
        {
            var tempEntries = new List<Entry>();
            var tempState = entries.Find(e => e.Id == entryId);

            if (tempState == null) return;
            tempEntries.AddRange(entries.Select(e =>
                !tempState.Equals(e) ? e : new Entry(e.Id, e.Name, GetEntryState(e.Id))));
            entries = tempEntries;
        }

        private List<AddedEntry> GetEntriesAfterRemoval(
    List<AddedEntry> inputAddedEntries, IReadOnlyCollection<RemovedEntry> inputRemovedEntries)
        {
            if (!inputRemovedEntries.Any()) return inputAddedEntries;

            var groupedRemovedEntries = GroupEntriesByEntryIdOrderByTime(inputRemovedEntries);
            var tempRemovedEntries = new List<AddedEntry>(inputAddedEntries);

            foreach (var removedEntry in groupedRemovedEntries)
            {
                tempRemovedEntries.RemoveAll(e =>
                    e.EntryId == removedEntry.Key && e.Timestamp < removedEntry.First().Timestamp);
            }

            return tempRemovedEntries;
        }

        private bool IsUserIdAllowed(int userId)
        {
            return !removedUserIds.Contains(userId);
        }

        private bool IsEntryRemoved(int entryId, long timestamp)
        {
            if (!removedEntries.Any()) return false;
            var removedEntriesUserIdIsAllowed = GetEntriesUserIdIsAllowed(removedEntries);
            var tempRemovedEntry = removedEntriesUserIdIsAllowed
                .Find(e => e.EntryId == entryId && e.Timestamp >= timestamp);
            return tempRemovedEntry != null;
        }

        private List<T> GetEntriesUserIdIsAllowed<T>(IEnumerable<T> collection)
            where T : IEntry
        {
            return collection
                .Where(u => !removedUserIds.Contains(u.UserId))
                .ToList();
        }

        private ILookup<int, T> GroupEntriesByEntryIdOrderByTime<T>(IEnumerable<T> collection)
            where T : IEntry
        {
            return collection
                .OrderByDescending(o => o.Timestamp)
                .ToLookup(p => p.EntryId);
        }
    }
}