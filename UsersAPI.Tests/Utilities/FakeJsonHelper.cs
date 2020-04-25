namespace UsersAPI.Tests.Utilities
{
    public static class FakeJsonHelper
    {
        /// <summary>
        /// Get fake valid user data in json - used for testing
        /// NOTE: CHANGING THE FAKE JSON BELOW WILL AFFECT THE TEST RESULTS!
        /// </summary>
        /// <returns>Fake User Data in Json</returns>
        public static string GetFakeValidUserDataJson()
        {
            return @"
{
'users':[
{
      'Id': 0,
      'Title': 'mr',
      'FirstName': 'brad',
      'LastName': 'gibson',
      'Email': 'brad.gibson@example.com',
      'Birthday': '1993-07-20',
      'MobileNumber': '011-962-7516',
      'ProfileImageLarge': 'https://randomuser.me/api/portraits/men/75.jpg',
      'ProfileImageThumbnail': 'https://randomuser.me/api/portraits/med/men/75.jpg'
    },
{
      'Id': 1,
      'Title': 'mrs',
      'FirstName': 'gomel',
      'LastName': 'tun',
      'Email': 'gomel.tun@example.com',
      'Birthday': '1995-09-10',
      'MobileNumber': '011-962-7516',
      'ProfileImageLarge': 'https://randomuser.me/api/portraits/men/75.jpg',
      'ProfileImageThumbnail': 'https://randomuser.me/api/portraits/med/men/75.jpg'
    },
{
      'Id': 2,
      'Title': 'mr',
      'FirstName': 'brad',
      'LastName': 'gibson',
      'Email': 'brad.gibson@example.com',
      'Birthday': '1993-07-20',
      'MobileNumber': '011-962-7516',
      'ProfileImageLarge': 'https://randomuser.me/api/portraits/men/75.jpg',
      'ProfileImageThumbnail': 'https://randomuser.me/api/portraits/med/men/75.jpg'
    },
{
      'Id': 3,
      'Title': 'miss',
      'FirstName': 'steph',
      'LastName': 'suan',
      'Email': 'steph.suan@example.com',
      'Birthday': '1993-07-20',
      'MobileNumber': '011-962-7516',
      'ProfileImageLarge': 'https://randomuser.me/api/portraits/men/75.jpg',
      'ProfileImageThumbnail': 'https://randomuser.me/api/portraits/med/men/75.jpg'
    },
{
      'Id': 4,
      'Title': 'miss',
      'FirstName': 'gamel',
      'LastName': 'tele',
      'Email': 'gamel.tele@example.com',
      'Birthday': '1993-07-20',
      'MobileNumber': '011-962-7516',
      'ProfileImageLarge': 'https://randomuser.me/api/portraits/men/75.jpg',
      'ProfileImageThumbnail': 'https://randomuser.me/api/portraits/med/men/75.jpg'
    },
{
      'Id': 5,
      'Title': 'mr',
      'FirstName': 'grat',
      'LastName': 'gibs',
      'Email': 'grat.gibs@example.com',
      'Birthday': '1993-07-20',
      'MobileNumber': '011-962-7516',
      'ProfileImageLarge': 'https://randomuser.me/api/portraits/men/75.jpg',
      'ProfileImageThumbnail': 'https://randomuser.me/api/portraits/med/men/75.jpg'
    },
{
      'Id': 6,
      'Title': 'mr',
      'FirstName': 'wat',
      'LastName': 'riv',
      'Email': 'wat.riv@example.com',
      'Birthday': '1993-07-20',
      'MobileNumber': '011-962-7516',
      'ProfileImageLarge': 'https://randomuser.me/api/portraits/men/75.jpg',
      'ProfileImageThumbnail': 'https://randomuser.me/api/portraits/med/men/75.jpg'
    }
]}";
        }
    }
}