﻿namespace Users.Domain.Entities
{
    public record UserAccessFail
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public User User { get; init; }
        private bool isLockOut;
        public DateTime? LockEnd { get;private set; }
        public int AccessFailCount { get; private set; }
        private UserAccessFail() { }
        public UserAccessFail(User user)
        {
            this.Id = Guid.NewGuid();
            this.User = user;
            this.UserId = user.Id;
        }
        public void Reset()
        {
            this.AccessFailCount = 0;
            this.LockEnd = null;
            this.isLockOut = false;
        }
        public void Fail()
        {
            this.AccessFailCount++;
            if (this.AccessFailCount>=3)
            {
                this.LockEnd = DateTime.Now.AddMinutes(5);
                this.isLockOut = true;
            }
        }
        public bool IsLockOut()
        {
            if (this.isLockOut)
            {
                if (DateTime.Now>this.LockEnd)
                {
                    Reset();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
