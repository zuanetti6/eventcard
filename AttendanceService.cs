namespace Myblazorapp.Services
{
    public class AttendanceService
    {
        // Simple in-memory attendance tracking: eventId -> set of emails
        private readonly Dictionary<int, HashSet<string>> _attendance = new();

        public Task RegisterAttendanceAsync(int eventId, string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return Task.CompletedTask;
            lock (_attendance)
            {
                if (!_attendance.TryGetValue(eventId, out var set))
                {
                    set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    _attendance[eventId] = set;
                }
                set.Add(email);
            }
            return Task.CompletedTask;
        }

        public Task<IReadOnlyCollection<string>> GetAttendeesAsync(int eventId)
        {
            lock (_attendance)
            {
                if (_attendance.TryGetValue(eventId, out var set))
                {
                    return Task.FromResult((IReadOnlyCollection<string>)set.ToList().AsReadOnly());
                }
                return Task.FromResult((IReadOnlyCollection<string>)Array.Empty<string>());
            }
        }
    }
}
