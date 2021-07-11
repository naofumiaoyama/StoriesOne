using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class User : Person
    {
        private IDictionary<Guid, Story> _stories;
        private IDictionary<Guid, User> _friends;
        public string DisplayName { get; set; }
        public string SelfIntroction { get; set; }
        public Timeline Timeline { get; set; }
        public string LivingPlace { get; set; }
        public string Occupation { get; set; }
        public IDictionary<Guid, Story> Stories
        {
            get { return this._stories; }
            set
            {
                if (value == null)
                {
                    System.Diagnostics.Debug.WriteLine("Stories Dictionary is null");
                }
                this._stories = value;
            }
        }

        public IDictionary<Guid, User> Friends
        {
            get { return this._friends; }
            set
            {
                if (value == null)
                {
                    System.Diagnostics.Debug.WriteLine("Stories Dictionary is null");
                }

                this._friends = value;
            }
        }

        public Picture ProfilePicture { get; set; }
    }
}
